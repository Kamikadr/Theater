using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Placement
{
    private static string fileName = "Placement";
    static PlacementObject _placementObject;
    static PlacementObject placementObject
    {
        get
        {
            return _placementObject;

        }
        set
        {
            if(!value.Equals(_placementObject))
            {
                _placementObject = value;
                onPlacementChange?.Invoke();
                saveChanges();
            }
        }
    }
    public static Action onPlacementChange;
    static Placement() 
    {
        _placementObject = createPlacementObject();
    }
    
    static PlacementObject createPlacementObject() 
    {
        if (!PlayerPrefs.HasKey(fileName))
        {
            PlacementScriptableObject placementScriptableObject = Resources.Load<PlacementScriptableObject>(fileName);
            return placementScriptableObject.placementObject;
        }
        else
        {
            string jsonText = PlayerPrefs.GetString(fileName);
            return JsonUtility.FromJson<PlacementObject>(jsonText);
        }
    }
    public static List<string> GetScenes()
    {
        List<string> sceneNames = new List<string>();
        foreach (TheaterScene inf in placementObject.theaterScenes) { sceneNames.Add(inf.name); }
        return sceneNames;
    }
    public static List<TheaterObject> getSceneObject(string sceneName)
    {
        for (int i = 0; i < placementObject.theaterScenes.Count; i++) 
        {
            if (placementObject.theaterScenes[i].name == sceneName) 
                return placementObject.theaterScenes[i].theaterObjects;
        }
        return null;
    }
    public static void setSceneObject(List<TheaterObject> objectPlacements, string sceneName)
    {
        int i = 0;
        for (; placementObject.theaterScenes[i].name != sceneName; i++);

        placementObject.theaterScenes[i].theaterObjects = objectPlacements;
    }

    static void saveChanges()
    {
        string jsonText = JsonUtility.ToJson(placementObject);
        PlayerPrefs.SetString(fileName, jsonText);
        PlayerPrefs.Save();
    }

    public static void SaveStringToPlacementObject(string jsonString)
    {
        try
        {
            placementObject = JsonUtility.FromJson<PlacementObject>(jsonString);
        }
        catch
        {
            return;
        }
        onPlacementChange?.Invoke();
    }
    public static string GetPlacementObjectAsString()
    {
        return JsonUtility.ToJson(placementObject);
    }
}

[System.Serializable]
public class PlacementObject
{
    public List<TheaterScene> theaterScenes;
}
[System.Serializable]
public class TheaterScene
{
    public string name;
    public List<TheaterObject> theaterObjects;
}
[System.Serializable]
public class TheaterObject
{
    public string name;
    public Position position;
    public Rotation rotation;
    public Scale localScale;
}
[System.Serializable]
public class Position 
{
    public float x;
    public float y;
    public float z;
}
[System.Serializable]
public class Rotation 
{
    public float x;
    public float y;
    public float z;
    public float w;
}
[System.Serializable]
public class Scale
{
    public float x;
    public float y;
    public float z;
}


