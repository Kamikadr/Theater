using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ARVideoContentLebeda : ARContent
{
    public GameObject videoRender;
    public List<VideoClip> videos;

    public VideoPlayer videoPlayer;
    [SerializeField]
    //public int namberOfVideo = 0;
    void Start()
    {
        

    }
    override protected void SetState(ARState state, float timeElapsed)
    {
		switch (state)
		{
            case ARState.Finish:
                videoRender.SetActive(false);
                videoPlayer.enabled = false;
                break;
            case ARState.State1:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                videoPlayer.clip = videos[0];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
            case ARState.State2:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                videoPlayer.clip = videos[1];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
            case ARState.State3:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                videoPlayer.clip = videos[2];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
            case ARState.State4:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                videoPlayer.clip = videos[3];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
            case ARState.Default:
                videoRender.SetActive(false);
                videoPlayer.enabled = false;
                break;
            case ARState.Dummy:
                break;
            default:
                break;


		}
    }
}
