using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ARParticleSystem : ARContent
{
    public List<ParticleSystem> particleSystems;
    protected override void SetState(ARState state, float timeElapsed)
    {
        base.SetState(state, timeElapsed);
        switch (state) 
        {
            case ARState.State1:
                Debug.Log("State 1");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[0].gameObject.SetActive(true);
                particleSystems[0].Play();
                break;

            case ARState.State2:
                Debug.Log("State 2");
                particleSystems[0].Pause();
                break;

            case ARState.Finish:
                Debug.Log("Finish");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                break;

            case ARState.State4:
                Debug.Log("Particals State 4");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[0].Play();
                particleSystems[0].time = 20f;
                break;

            case ARState.State5:
                Debug.Log("State 5");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[1].gameObject.SetActive(true);
                particleSystems[1].Play();
                break;

            case ARState.State6:
                Debug.Log("State 6");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[2].Play();
                break;

            case ARState.State7:
                Debug.Log("State 7");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[2].Play();
                //particleSystems[2].emission.rateOverTime.constant = 30;
                break;

            case ARState.State8:
                Debug.Log("State 7");
                foreach (ParticleSystem system in particleSystems) system.Stop();
                particleSystems[2].Play();
                //particleSystems[2].emission.rateOverTime.constant = 30; нужно еще сильнее увеличить emission!!!
                break;

            case ARState.Dummy:
                break;
        }
    }
}
