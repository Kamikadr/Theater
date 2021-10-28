using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Schedule", menuName = "Schedule", order = 51)]
public class ScheduleScriptableObject : ScriptableObject
{
    [SerializeField]
    public ScheduleObject scheduleObject;
}
