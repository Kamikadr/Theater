using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using Sirenix.OdinInspector;

public class Starter : MonoBehaviour
{
    public double addSeconds = 0;
    
    [SerializeField]
    Server server;
    private void Start()
    {
    }
    [Button("StartScene")]
    public void StartScene() 
    {
        print(Schedule.GetScheduleObject().sceneDelay);
        ScheduleObject scheduleObject = Schedule.GetScheduleObject();
        foreach (Scene sceneData in scheduleObject.SceneList)
        {
            DateTime dateTimeNow = DateTime.Now.AddSeconds(addSeconds);
            
            sceneData.dateTime = dateTimeNow.ToFileTime();
            print(dateTimeNow.ToFileTime());
        }
        Schedule.saveChanges();
        server.BroadCastSchedule();
    }
}
