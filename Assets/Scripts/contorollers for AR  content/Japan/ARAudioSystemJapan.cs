using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAudioSystemJapan : ARContent
{

    public List<AudioSource> audioList;

    protected override void SetState(ARState state, float timeElapsed)
    {
        base.SetState(state, timeElapsed);
        switch (state)
        {
            case ARState.State1:
                Debug.Log("State 1 Audio");
                TurnOffAudio();
                if (timeElapsed <= 0)
                {
                    audioList[0].Play();
                }
                else
                {
                    audioList[0].time = timeElapsed;
                    audioList[0].Play();
                }
                break;
            case ARState.State2:
                Debug.Log("State 2 Audio");
                TurnOffAudio();
                if (timeElapsed < 0)
                {
                    audioList[1].Play();
                }
                else
                {
                    audioList[1].time = timeElapsed;
                    audioList[1].Play();
                }
                break;
            case ARState.Finish:
                Debug.Log("Finish Audio");
                TurnOffAudio();
                break;
            case ARState.Dummy:
                break;
            case ARState.Default:
                break;
            case ARState.Idle:
                break;
        }
    }
    void TurnOffAudio()
    {
        foreach (AudioSource audio in audioList) audio.Stop();
    }
}

