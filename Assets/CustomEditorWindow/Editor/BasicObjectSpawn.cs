using UnityEngine;
using UnityEditor;

public class BasicObjectSpawn : EditorWindow
{
    string objectBaseName = "";
    int objectID = 1;
    GameObject objectToSpawn;
    float objectScale;
    float spawnRadius = 5f;
    [MenuItem("My Tools/Tools/Basic Object Spawner")]
    public static void ShowWindow()
    {
        //GetWindow is a method inherited from the EditorWindow class
        //GetWindow(typeof(className));
        GetWindow(typeof(BasicObjectSpawn));
    }
    
    //Where settings Feild & Button 
    private void OnGUI() {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);

        objectBaseName = EditorGUILayout.TextField("Base Name",objectBaseName);
        objectID = EditorGUILayout.IntField("Object ID",objectID);
        objectScale = EditorGUILayout.Slider("Object Scale",objectScale, 0.5f, 3f);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab To Spawn",objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Object"))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
            return;             
        }

        if (objectBaseName == string.Empty)
        {
            Debug.LogError("Error: Please enter a base name for the object.");
            return;
        }

        Vector2 spawnCircle = Random.insideUnitCircle*spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        newObject.name = objectBaseName +objectID;
        newObject.transform.localScale = Vector3.one*objectScale;

        objectID++;
    }
}
