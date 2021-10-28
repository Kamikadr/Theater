using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoOffScreen1 : MonoBehaviour
{
    
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
    }

}
