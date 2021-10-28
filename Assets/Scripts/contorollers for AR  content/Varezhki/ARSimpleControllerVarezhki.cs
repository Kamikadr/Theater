using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSimpleControllerVarezhki: ARContent
{
    [SerializeField]
    public List<GameObject> objects;
    void Start()
    {
    }

    override protected void SetState(ARState state, float timeElapsed)
    {
        switch (state)
        {
            case ARState.Finish:
                for (int i = 0; i < objects.Count; i++)
                    objects[i].SetActive(false);
                break;
            case ARState.State1:
                TurnOffObjects();
                objects[0].SetActive(true);
                break;
            case ARState.State2:
                objects[1].SetActive(true);
                break;
            case ARState.State3:
                //TurnOffObjects();
                objects[2].SetActive(true);
                break;
            case ARState.State4:
                objects[3].SetActive(true);          
                break;
            case ARState.State5:
                objects[4].SetActive(true);
                break;

            case ARState.Default:
                foreach (var obj in objects)
                {
                    obj.SetActive(true);
                }
                break;
            case ARState.Dummy:
                break;
            default:
                break;
        }
    }

    void TurnOffObjects()
    {
        for (int i = 0; i < objects.Count; i++)
            objects[i].SetActive(false);
    }
}
