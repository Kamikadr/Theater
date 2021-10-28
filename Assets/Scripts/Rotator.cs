using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : ARContent
{
    [SerializeField]
    float rotationSpeed = 1.71f;

    [SerializeField]
    bool isDrivedByEventSystem = false;

    bool rotate = true;
    // Update is called once per frame

    private void Start()
    {
        if (isDrivedByEventSystem)
            rotate = false;
        else
            rotate = true;
    }

    void Update()
    {
        if(rotate)
            transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }

    protected override void SetState(ARState state, float timeElapsed)
    {
        if(isDrivedByEventSystem)
        {
            base.SetState(state, timeElapsed);
            switch (state)
            {
                case ARState.State1:
                    rotate = true;
                    break;

                case ARState.Finish:
                    rotate = false;
                    break;

                case ARState.Default:
                    break;

                case ARState.Dummy:
                    break;
            }
        }
    }
}
