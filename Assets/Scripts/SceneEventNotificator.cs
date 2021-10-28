using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;
using System.Linq;

public class SceneEventNotificator : MonoBehaviour
{
    public static SceneEventNotificator instance;

    [SerializeField] private string mySceneName;
    int mySceneindex;
    [SerializeField] private List<ARContent> contentList;
    public List<string> actNames {get; private set;}
    private List<int> actTimeOffsets;
    bool[] actsPastStatus;

    private DateTime SceneStartDateTime;
    
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
        {
            instance = this;


            //TODO autostart for new clients
            mySceneindex = GetMySceneIndex();
            if(mySceneindex != -1)
            {
                Schedule.onScheduleChange += HandleScheduleChanges;
            }
              
        }
    }
    private int GetMySceneIndex()
    {
        for (int sceneIndex = 0; sceneIndex < Schedule.GetScheduleObject().SceneList.Count; sceneIndex++)
        {
            if (Schedule.GetScheduleObject().SceneList[sceneIndex].nameScene == mySceneName)
            {
                return sceneIndex;
            }
        }
        return -1;
    }

    public void HandleScheduleChanges()
    {
        print(DateTime.Now.ToString());
        if (NotificationProcessCoroutine != null)
            StopCoroutine(NotificationProcessCoroutine);

        actNames = new List<string>();
        actTimeOffsets = new List<int>();

        ScheduleObject schedule = Schedule.GetScheduleObject();
        for (int actIndex = 0; actIndex < Schedule.GetScheduleObject().SceneList[mySceneindex].actList.Count; actIndex++)
        {
            actNames.Add(Schedule.GetScheduleObject().SceneList[mySceneindex].actList[actIndex].name);
            actTimeOffsets.Add(Schedule.GetScheduleObject().SceneList[mySceneindex].actList[actIndex].offset);
        }
        actsPastStatus = Enumerable.Repeat(false, actNames.Count).ToArray(); ;
        SceneStartDateTime = DateTime.FromFileTime(schedule.SceneList[mySceneindex].dateTime).AddSeconds(schedule.sceneDelay);
        print(schedule.sceneDelay);
        print(SceneStartDateTime.ToString());


        foreach (ARContent arcontent in contentList)
        {
            arcontent.TakeActsData();
        }

        PerformNearestEventFire();
    }

    //TODO abs module logic - from past start logic
    private void PerformNearestEventFire()
    {
        print("FireNearestEvent");
        int i;
        for (i = 0; i < actsPastStatus.Length && actsPastStatus[i]; i++);

        if (i == actsPastStatus.Length)
            return;

        int nearestTime = actTimeOffsets[i];
        int nearestEventIndex = i;

        for (; i < actTimeOffsets.Count; i++)
        {
            if ((nearestTime > actTimeOffsets[i]) && actsPastStatus[i] == false)
            {
                nearestTime = actTimeOffsets[i];
                nearestEventIndex = i;
            }
        }
        actsPastStatus[nearestEventIndex] = true;

        float eventDelay = (float)(SceneStartDateTime.AddSeconds(nearestTime) - DateTime.Now.ToLocalTime()).TotalSeconds;
        NotificationProcessCoroutine = SendNotificationsCoroutine(actNames[nearestEventIndex], eventDelay);
        StartCoroutine(NotificationProcessCoroutine);
    }

    IEnumerator NotificationProcessCoroutine;
    IEnumerator SendNotificationsCoroutine(string actName, float delay)
    {
        print("Wait until...");
        if (delay > 0)
        {
            yield return new WaitForSecondsRealtime(delay);
            SendNotifications(actName, 0);
        }
        else
        {
            SendNotifications(actName, delay);
        }
        print("event: " + actName);
        PerformNearestEventFire();
    }

    GlitchSurge glitchSurge = null;

    void SendNotifications(string actName, float delay)
    {
        if(glitchSurge != null)
        {
            glitchSurge.Surge();
        }
        else
        {
            glitchSurge = Camera.main.GetComponent<GlitchSurge>();
            glitchSurge.Surge();
        }

        foreach (ARContent arcontent in contentList)
        {
            Debug.Log(actName + " delay: " + delay);
            arcontent.GetMessage(actName, Math.Abs(delay));
        }
    }
}
