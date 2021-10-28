using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ConnectionIndicator : MonoBehaviour
{
    [SerializeField]
    public Color connected;
    [SerializeField]
    public Color notConnected;
    [SerializeField]
    public Color undefined;
    [SerializeField]
    public Color successMessageHandling;
    [SerializeField]
    public Color failMessageHandling;

    [SerializeField]
    public Image image;

    [Button("Connected")]
    public void Connected()
    {
        image.color = connected;
    }

    [Button("NotConnected")]
    public void NotConnected()
    {
        image.color = notConnected;
    }

    [Button("Undefined")]
    public void Undefined()
    {
        image.color = undefined;
    }

    [Button("Success")]
    public void Success()
    {
        TimeDraw(successMessageHandling);
    }

    [Button("Fail")]
    public void Fail()
    {
        TimeDraw(failMessageHandling);
    }

    IEnumerator coroutine;
    public void TimeDraw(Color color)
    {
        timeElapsed = 0f;
        if (!coroutineRunFlag)
        {
            StartCoroutine(TimeDrawCoroutine(image.color));
            coroutineRunFlag = true;
            image.color = color;
        }
        else if(image.color != color)
        {
            image.color = color;
        }
    }

    float timeElapsed = 0f;
    float successIndicationTick = 8f;
    
    bool coroutineRunFlag = false;  
    IEnumerator TimeDrawCoroutine(Color color)
    {
        while (timeElapsed < successIndicationTick)
        {
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        coroutineRunFlag = false;
        image.color = color;
    }

}
