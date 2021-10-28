using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects;
    private List<TheaterObject> objectPlacements;
    private Dictionary<string, GameObject> sceneObjectsMap = new Dictionary<string, GameObject>();
    [SerializeField]
    string sceneName;
    private void Start()
    {
        DoPlacementChanges();
        Placement.onPlacementChange += DoPlacementChanges;
    }
    public void ConfigToScene() 
    {
        for (int i = 0; i < objectPlacements.Count; i++)
        {
            try 
            {
                Vector3 proposedPosition = new Vector3(objectPlacements[i].position.x, objectPlacements[i].position.y, objectPlacements[i].position.z);
                if (sceneObjectsMap[objectPlacements[i].name].transform.position != proposedPosition)
                    sceneObjectsMap[objectPlacements[i].name].transform.position = proposedPosition;

                Quaternion proposedRotation = new Quaternion(objectPlacements[i].rotation.x, objectPlacements[i].rotation.y, objectPlacements[i].rotation.z, objectPlacements[i].rotation.w); 
                if (sceneObjectsMap[objectPlacements[i].name].transform.rotation != proposedRotation)
                    sceneObjectsMap[objectPlacements[i].name].transform.rotation = proposedRotation;

                Vector3 proposedScale = new Vector3(objectPlacements[i].localScale.x, objectPlacements[i].localScale.y, objectPlacements[i].localScale.z);
                if (sceneObjectsMap[objectPlacements[i].name].transform.localScale != proposedScale)
                    sceneObjectsMap[objectPlacements[i].name].transform.localScale = proposedScale;
            }
            catch
            {
                continue;
            }
                
        }
    }
    private void SceneToConfig() 
    {
        for(int i = 0; i < objectPlacements.Count; i++) 
        {
            try
            {
                objectPlacements[i].position.x = sceneObjectsMap[objectPlacements[i].name].transform.position.x;
                objectPlacements[i].position.y = sceneObjectsMap[objectPlacements[i].name].transform.position.y;
                objectPlacements[i].position.z = sceneObjectsMap[objectPlacements[i].name].transform.position.z;

                objectPlacements[i].rotation.x = sceneObjectsMap[objectPlacements[i].name].transform.rotation.x;
                objectPlacements[i].rotation.y = sceneObjectsMap[objectPlacements[i].name].transform.rotation.y;
                objectPlacements[i].rotation.z = sceneObjectsMap[objectPlacements[i].name].transform.rotation.z;
                objectPlacements[i].rotation.w = sceneObjectsMap[objectPlacements[i].name].transform.rotation.w;

                objectPlacements[i].localScale.x = sceneObjectsMap[objectPlacements[i].name].transform.localScale.x;
                objectPlacements[i].localScale.y = sceneObjectsMap[objectPlacements[i].name].transform.localScale.y;
                objectPlacements[i].localScale.z = sceneObjectsMap[objectPlacements[i].name].transform.localScale.z;
            }
            catch
            {
                continue;
            }

        }
        
    }
    private void createSceneMap() 
    {
        for (int i = 0; i < objects.Count; i++)
        {
            sceneObjectsMap.Add(objects[i].transform.name, objects[i]);
        }
            

    }

    public void DoPlacementChanges()
    {
        objectPlacements = Placement.getSceneObject(sceneName);
        createSceneMap();
        ConfigToScene();
    }
}
