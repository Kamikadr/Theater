using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstCalibration : MonoBehaviour
{
    public CanvasScaler canvas;
    public RectTransform rectTransform;
    public Button calibrationButton;
    public MarkerAndAnchorCalibration script;
    
    void Start()
    {
        Vector2 standartSize = rectTransform.sizeDelta;
        Vector2 standartPosition = rectTransform.anchoredPosition;
            Text buttonText = calibrationButton.transform.Find("NotificationText").GetComponent<Text>();
            buttonText.text = "Необходимо произвести первоначальную калибровку";
            float resolution = (float)Screen.width / Screen.height;
            float certainY = canvas.referenceResolution.x / 2 / resolution;
            float certainX = (canvas.referenceResolution.x - 200) / 2;
            rectTransform.sizeDelta = new Vector2(canvas.referenceResolution.x / 2, canvas.referenceResolution.x / 2);
            rectTransform.anchoredPosition = new Vector2(-certainX, -certainY);
            calibrationButton.onClick.AddListener(delegate 
            {
                script.StartCalibration();
                rectTransform.sizeDelta = standartSize;
                rectTransform.anchoredPosition = standartPosition;
                buttonText.text = "";
            });
    }


}
