using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARParticalSystemAlphabet : ARContent
{
    // Start is called before the first frame update
    void Start()
    {

    }
    //[snow, smoke]
    public List<ParticleSystem> particleSystems;
    protected override void SetState(ARState state, float timeElapsed)
    {
        base.SetState(state, timeElapsed);
        switch (state)
        {
            case ARState.State1:
                Debug.Log("State 1 PS alpha");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[0].Play();
                break;
            case ARState.State2:
                Debug.Log("State 2 PS alpha");
                particleSystems[1].Play();
                break;
            case ARState.Finish:
                foreach (ParticleSystem system in particleSystems) system.Stop();
                break;
            case ARState.Dummy:
                break;
        }
    }
}
