using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAudioAlphabet : ARContent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            case ARState.Dummy:
                break;
            case ARState.Finish:
                TurnOffAudio();
                break;
        }
    }
    void TurnOffAudio()
    {
        foreach (AudioSource audio in audioList) audio.Stop();
    }
}
