using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAnimatedContentAlphabet : ARContent
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
                objects[0].SetActive(true);
                //запускаем вращение
                objects[0].GetComponent<Animator>().SetTrigger("HouseRotation");
                //animator.SetTrigger("Start rotation");//"Start rotation"
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
