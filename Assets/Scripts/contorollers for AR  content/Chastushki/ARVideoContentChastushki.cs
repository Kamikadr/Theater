using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ARVideoContentChastushki : ARContent
{
    public GameObject videoRender;
    public List<VideoClip> videos;

    public VideoPlayer videoPlayer;
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
                //videoRender.enabled = true;
                videoPlayer.clip = videos[1];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
            case ARState.State3:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                //videoRender.enabled = true;
                videoPlayer.clip = videos[2];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
            case ARState.State4:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                //videoRender.enabled = true;
                videoPlayer.clip = videos[3];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
                case ARState.State5:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                videoPlayer.clip = videos[4];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
                case ARState.State6:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                videoPlayer.clip = videos[5];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                break;
            case ARState.State7:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                //videoRender.enabled = true;
                videoPlayer.clip = videos[0];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                videoPlayer.isLooping = true;
                break;
            case ARState.State8:
                videoPlayer.enabled = true;
                videoRender.SetActive(true);
                //videoRender.enabled = true;
                videoPlayer.clip = videos[2];
                videoPlayer.time = timeElapsed;
                videoPlayer.Play();
                videoPlayer.isLooping = true;
                break;
            case ARState.Default:
                videoRender.SetActive(false);
                videoPlayer.enabled = false;
                break;
            case ARState.Dummy:
                break;
            default:
                Console.WriteLine("Default case");
                break;


		}
    }
}
