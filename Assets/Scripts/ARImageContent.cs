using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ARImageContent : ARContent
{
    public List<Image> images;
    public List<Sprite> pictures;
    void Start()
    {
    }
    override protected void SetState(ARState state, float timeElapsed)
    {
        switch (state)
        {
            case ARState.Finish:
                foreach(var picture in images)
				{
                    picture.enabled = false;
				}
                break;
            case ARState.State2:
                Debug.Log("State 2 is turned on!");
                foreach (var picture in images)
                {
                    picture.enabled = false;
                }
                images[0].enabled = true;
                break;
            case ARState.State3:
                Debug.Log("State 2 is turned on!");
                foreach (var picture in images)
                {
                    picture.enabled = false;
                }
                images[1].enabled = true;
                break;
            case ARState.State4:
                Debug.Log("State 2 is turned on!");
                foreach (var picture in images)
                {
                    picture.enabled = false;
                }
                images[0].enabled = true;
                images[0].sprite = pictures[1];
                break;
            case ARState.State5:
                Debug.Log("State 2 is turned on!");
                foreach (var picture in images)
                {
                    picture.enabled = false;
                }
                images[1].enabled = true;
                break;
            case ARState.State1:
                Debug.Log("State1 is turned on!");
                foreach (var picture in images)
                {
                    picture.enabled = true;
                }
                break;
            case ARState.Idle:
                foreach (var picture in images)
                {
                    picture.enabled = true;
                }
                break;
            case ARState.Default:
                foreach (var picture in images)
                {
                    Debug.Log("Default is turned on!");
                    picture.enabled = false;
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
