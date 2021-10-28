using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    float a = 0;
    public Image progressCricle;
    public GameObject imageAnchor;
    void Start()
    {
        imageAnchor.SetActive(false);
        
    }

    public void UpdateProgressBar(float progressLevel, float maxLevel)
	{
        progressCricle.fillAmount = progressLevel / maxLevel;
	}
    public void TurnOnProgressBar()
	{
        imageAnchor.SetActive(true);
	}
    public void TurnOffProgressBar()
	{
        imageAnchor.SetActive(false);
	}
}
