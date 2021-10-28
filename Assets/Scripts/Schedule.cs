using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class Schedule
{
    const string fileName = "Schedule";
    static ScheduleObject scheduleObject;
    public static Action onScheduleChange;

    public static  ScheduleObject GetScheduleObject()
    {
        return scheduleObject;
    }

    static Schedule() 
    {
        scheduleObject = createScheduleObject();
    }

    public static string GetScheduleObjectAsString()
    {
        return JsonUtility.ToJson(scheduleObject);
    }

    public static ScheduleObject createScheduleObject() 
    {
        if (!PlayerPrefs.HasKey("file"))
        {
            ScheduleScriptableObject scheduleScriptableObject = Resources.Load<ScheduleScriptableObject>(fileName);
            return scheduleScriptableObject.scheduleObject;
        }
        else
        {
            string jsonText = PlayerPrefs.GetString("file");
            return JsonUtility.FromJson<ScheduleObject>(jsonText);
        }
    }

    public static ScheduleObject createScheduleObject(string jsonString)
    {
        return JsonUtility.FromJson<ScheduleObject>(jsonString);
    }

    public static List<string> getScene() 
    {
        List<string> sceneNames = new List<string>();
        foreach (Scene inf in scheduleObject.SceneList) { sceneNames.Add(inf.nameScene); }
        return sceneNames;
    }

    public static List<int> getSceneTiming(int index) 
    {
        List<int> timings = new List<int>();
            foreach (Act act in scheduleObject.SceneList[index].actList) { timings.Add(act.offset); }
        return timings;
    }

    public static void setSceneTiming(int index, List<int> timings) 
    {
        for (int i = 0; i < timings.Count; i++) { scheduleObject.SceneList[index].actList[i].offset = timings[i]; }
    }

    public static List<string> getSceneActName(int index)
    {
        List<string> names = new List<string>();
        foreach (Act timing in scheduleObject.SceneList[index].actList) { names.Add(timing.name); }
        return names;
    }

    public static int getDelay() 
    { 
        return scheduleObject.sceneDelay; 
    }

    public static void setDelay(int value) 
    { 
        scheduleObject.sceneDelay = value;
    }

    public static void saveChanges()
    {
        string jsonText = JsonUtility.ToJson(scheduleObject);
        PlayerPrefs.SetString("file", jsonText);
        PlayerPrefs.Save();

        onScheduleChange?.Invoke();
    }


    public static void SaveStringToScheduleObject(string scheduleSting)
    { 
        try
        {
            scheduleObject = JsonUtility.FromJson<ScheduleObject>(scheduleSting);
        }
        catch
        {
            return;
        }
        onScheduleChange?.Invoke();
    }



    //не доделано
    public static void setTime() 
    {
        var a = DateTime.UtcNow;
    }
}

// классы - контейнеры для десериализованного json файла
[System.Serializable]
public class Act
{
    public string name;
    public int offset;
}
[System.Serializable]
public class Scene
{
    public string nameScene;
    public long dateTime;
    public List<Act> actList;
}
[System.Serializable]
public class ScheduleObject
{
    public List<Scene> SceneList;
    public int sceneDelay;
}

