using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ARParticleSystemErsh : ARContent
{
    public List<ParticleSystem> particleSystems;
    protected override void SetState(ARState state, float timeElapsed)
    {
        base.SetState(state, timeElapsed);
        switch (state) 
        {
            case ARState.State1:
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[0].gameObject.SetActive(true);
                particleSystems[0].Play();
                break;

            case ARState.State2:
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[0].gameObject.SetActive(true);
                particleSystems[0].Pause();
                break;

            case ARState.Default:
                break;

            case ARState.Finish:
                foreach (ParticleSystem system in particleSystems) system.Stop();
                break;

            case ARState.Dummy:
                break;
        }
    }
}
