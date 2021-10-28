using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSimpleContentAlphabet : ARContent
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
            case ARState.State1:
                objects[0].SetActive(true);
                break;
            case ARState.Finish:
                TurnOffObjects();
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
