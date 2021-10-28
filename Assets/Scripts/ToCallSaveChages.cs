using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class ToCallSaveChages : MonoBehaviour
{
    private Transform prevTransform;
	public GameObject anchor;
	public Text text;
    void Start()
    {
		prevTransform = anchor.transform;
    }
	private void Update()
	{
	    if(prevTransform != anchor.transform)
		{
			text.text = "anchor position is chanched";
		}
	}


}
