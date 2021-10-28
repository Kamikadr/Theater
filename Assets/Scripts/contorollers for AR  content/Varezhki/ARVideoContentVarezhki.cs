using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ARVideoContentVarezhki : ARContent
{
    public List<GameObject> videoRenderGameObjs;
    public List<VideoClip> videos;

    public List<VideoPlayer> videoPlayerOfGameObjs;
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
                //1 2
                Console.WriteLine("State 1 VIDEO VAREZHKI");
                videoRenderGameObjs[1].SetActive(true);
                videoPlayerOfGameObjs[1].enabled = true;
                videoPlayerOfGameObjs[1].clip = videos[1];
                videoPlayerOfGameObjs[1].Play();

                videoRenderGameObjs[2].SetActive(true);
                videoPlayerOfGameObjs[2].enabled = true;
                videoPlayerOfGameObjs[2].clip = videos[3];
                videoPlayerOfGameObjs[2].Play();
                break;
            case ARState.State2:
                //6
                videoRenderGameObjs[6].SetActive(true);
                videoPlayerOfGameObjs[6].enabled = true;
                videoPlayerOfGameObjs[6].clip = videos[6];
                videoPlayerOfGameObjs[6].Play();
                break;
            case ARState.State3:
                //3
                videoRenderGameObjs[3].SetActive(true);
                videoPlayerOfGameObjs[3].enabled = true;
                videoPlayerOfGameObjs[3].clip = videos[2];
                videoPlayerOfGameObjs[3].Play();
                break;
            case ARState.State4:
                //7 4 
                videoRenderGameObjs[7].SetActive(true);
                videoPlayerOfGameObjs[7].enabled = true;
                videoPlayerOfGameObjs[7].clip = videos[7];
                videoPlayerOfGameObjs[7].Play();

                videoRenderGameObjs[4].SetActive(true);
                videoPlayerOfGameObjs[4].enabled = true;
                videoPlayerOfGameObjs[4].clip = videos[4];
                videoPlayerOfGameObjs[4].Play();
                break;
            case ARState.State5:
                //5 
                videoRenderGameObjs[5].SetActive(true);
                videoPlayerOfGameObjs[5].enabled = true;
                videoPlayerOfGameObjs[5].clip = videos[5];
                videoPlayerOfGameObjs[5].Play();
                break;
            case ARState.State6:
                Console.WriteLine("SUN VIDEO VAREZHKI state 6");
                videoRenderGameObjs[0].SetActive(true);
                videoPlayerOfGameObjs[0].enabled = true;
                videoPlayerOfGameObjs[0].clip = videos[0];
                videoPlayerOfGameObjs[0].Play();

                break;
            case ARState.State7:
                //start
                foreach (GameObject ren in videoRenderGameObjs)
                {
                    ren.SetActive(false);
                }
                foreach (VideoPlayer vid in videoPlayerOfGameObjs)
                {
                    vid.enabled = false;
                }
                break;
            case ARState.Finish:
                foreach (GameObject ren in videoRenderGameObjs)
                {
                    ren.SetActive(false);
                }
                foreach (VideoPlayer vid in videoPlayerOfGameObjs)
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
