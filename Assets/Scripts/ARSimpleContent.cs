using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSimpleContent : ARContent
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
                for(int i = 0;i<objects.Count;i++)
                    objects[i].SetActive(false);
                break;
            case ARState.State1:
                TurnOffObjects();
                objects[1].SetActive(true);
                break;
            case ARState.State2:
                TurnOffObjects();
                objects[0].SetActive(true);
                break;
            case ARState.State3:
                TurnOffObjects();
                objects[2].SetActive(true);
                break;
            case ARState.State4:
                TurnOffObjects();
                objects[0].SetActive(false);
                for (int i = 1; i < 5; i++)
                {
                    objects[i].SetActive(true);
                }
                break;
            case ARState.State5:
                TurnOffObjects();
                objects[0].SetActive(false);
                for (int i = 1; i < 8; i++)
                {
                    objects[i].SetActive(true);
                }
                break;
            case ARState.State6:
                TurnOffObjects();
                objects[0].SetActive(false);
                for (int i = 1; i < 10; i++)
                {
                    objects[i].SetActive(true);
                }
                break;
            case ARState.Idle:
                break;

            case ARState.Default: 
                foreach(var obj in objects)
				{
                    obj.SetActive(true);
				}
                break;
            case ARState.Dummy:
                break;



            case ARState.State9:
                TurnOffObjects();
                objects[0].SetActive(false);
                for (int i = 1; i < 8; i++)
                {
                    objects[i].SetActive(true);
                }
                break;

            case ARState.State7:
                TurnOffObjects();
                objects[10].SetActive(true);
                break;
            case ARState.State8:
                TurnOffObjects(); 
                for (int i = 1; i < 13; i++)
                {
                    objects[i].SetActive(true);
                }
                objects[10].SetActive(false);
                break;
            case ARState.State10:
                TurnOffObjects();
                objects[2].SetActive(true);
                objects[objects.Count - 1].SetActive(true);
                break;
            case ARState.State11:
                TurnOffObjects();
                objects[objects.Count - 1].SetActive(true);
                objects[objects.Count - 2].SetActive(true);
                break;
            case ARState.State12:
                TurnOffObjects();
                objects[0].SetActive(true);
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
