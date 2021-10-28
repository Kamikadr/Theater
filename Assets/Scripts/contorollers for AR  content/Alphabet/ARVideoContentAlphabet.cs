using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ARVideoContentAlphabet : ARContent
{
    public List<GameObject> videoRender;
    public List<VideoClip> videos;

    public List<VideoPlayer> videoPlayer;
    [SerializeField]
    //public int namberOfVideo = 0;
    void Start()
    {
        //videoPlayer = GetComponent<VideoPlayer>();

    }
    override protected void SetState(ARState state, float timeElapsed)
    {
        switch (state)
        {

            case ARState.State1:
                videoRender[0].SetActive(true);
                videoPlayer[0].enabled = true;
                videoPlayer[0].clip = videos[0];
                videoPlayer[0].Play();
                break;
            case ARState.State2:
                videoRender[1].SetActive(true);
                videoPlayer[1].enabled = true;
                videoPlayer[1].clip = videos[0];
                videoPlayer[1].Play();
                break;
            case ARState.State3:
                videoRender[2].SetActive(true);
                videoPlayer[2].enabled = true;
                videoPlayer[2].clip = videos[0];
                videoPlayer[2].Play();
                break;
            case ARState.Finish:
                foreach (GameObject ren in videoRender) 
                {
                    ren.SetActive(false);
                }
                foreach (VideoPlayer vid in videoPlayer)
                {
                    vid.enabled = false;
                }
                break;
            case ARState.Dummy:
                break;
            default:
                Console.WriteLine("Default case");
                break;


        }
    }
}
