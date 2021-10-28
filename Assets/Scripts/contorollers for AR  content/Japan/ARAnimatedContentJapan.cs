using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAnimatedContentJapan : ARContent
{ 
    [SerializeField]
    public List<GameObject> objects;
    [SerializeField]
    public List<string> triggers;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    override protected void SetState(ARState state, float timeElapsed)
    {
        switch (state)
        {
            case ARState.Finish:
                TurnOffObjects();
                break;
            case ARState.State1:
                //просто вкючить лес
                objects[0].SetActive(true);
                break;
            case ARState.State2:
                //запускаем вращение леса
                objects[0].GetComponent<Animator>().SetTrigger("Start rotation");
                //animator.SetTrigger("Start rotation");//"Start rotation"
                break;
            case ARState.State3:
                //включаем солнце и запускаем его восход
                objects[0].SetActive(true);
                objects[0].GetComponent<Animator>().SetTrigger("Sunset");
                //animator.SetTrigger("Sunset");//"Sunset"
                break;
            case ARState.Dummy:
                break;
            case ARState.Default:
                break;
            case ARState.Idle:
                break;
        }
    }

    void TurnOffObjects()
    {
        for (int i = 0; i < objects.Count; i++)
            objects[i].SetActive(false);
    }
}

