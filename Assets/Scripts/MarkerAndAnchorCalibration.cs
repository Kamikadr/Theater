using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class MarkerAndAnchorCalibration : MonoBehaviour
{
    UnityEvent OnAnchorChange;
    [SerializeField]
    private Transform anchor;

    ARTrackedImageManager myARTrackedImageManager;
    public float timeOfFullCalibration;
    public float positionDelta;
    public float maxDeltaAngle;
    public Text calibrationText;
    [SerializeField]
    bool calibratingStatus = false;
    public float timeOfCalibrationProgress = 0;
    Transform previousImageTransform;
    Quaternion previousQuaternion = Quaternion.identity;
    ProgressBarScript progressBar;


    private void Awake()
    {
        AnchorDataTransfer.anchor = anchor;
    }

    void Start()
    {
        myARTrackedImageManager = GetComponent<ARTrackedImageManager>();
        progressBar = GetComponent<ProgressBarScript>();
        calibratingStatus = false;
    }

    public void StartCalibration()
	{
        IEnumerator enumerator = TrackingProggress();
        StopCoroutine(enumerator);
        StartCoroutine(TrackingProggress());
    }


    ARTrackedImage targetMarker;
    IEnumerator TrackingProggress()
	{
        myARTrackedImageManager.enabled = true;
        calibrationText.text += "\n Start";
        progressBar.TurnOnProgressBar();
        progressBar.UpdateProgressBar(timeOfCalibrationProgress, timeOfFullCalibration);
        calibrationText.enabled = true;
        while (timeOfCalibrationProgress < timeOfFullCalibration)
        {
            yield return null;
            if (targetMarker == null)
			{
                foreach (var trackedImage in myARTrackedImageManager.trackables)
                {
                    //calibrationText.text += "\n in foreach";
                    if (trackedImage.trackingState == TrackingState.Tracking)
                    {
                        targetMarker = trackedImage;
                        targetMarker.gameObject.SetActive(true);
                        previousImageTransform = targetMarker.gameObject.transform;

                        calibrationText.text += "\n first image's tracked!";
                        break;
                    }
                }
            }
            else
			{
                if(targetMarker.trackingState != TrackingState.Tracking)
				{
                    ResetCalibrationProgress();
                }
                else
				{
                    float angle = Quaternion.Angle(previousImageTransform.rotation, targetMarker.gameObject.transform.rotation);
                    if (System.Math.Abs(targetMarker.gameObject.transform.position.x - previousImageTransform.position.x) <= positionDelta &&
                System.Math.Abs(targetMarker.gameObject.transform.position.y - previousImageTransform.position.y) <= positionDelta &&
                System.Math.Abs(targetMarker.gameObject.transform.position.z - previousImageTransform.position.z) <= positionDelta &&
                System.Math.Abs(angle) <= maxDeltaAngle)
                    {
                        //calibrationText.text += "\n Stable vision";
                        //calibrationText.text += Time.deltaTime;
                        timeOfCalibrationProgress += Time.deltaTime;
                        progressBar.UpdateProgressBar(timeOfCalibrationProgress, timeOfFullCalibration);
                    }
                    else
                    {
                        calibrationText.text += "\n Unstable tracking! Reset progress!";
                        ResetCalibrationProgress();
                    }

                    previousImageTransform = targetMarker.gameObject.transform;
                }
            }
        }

        //Success!

        anchor.transform.position = previousImageTransform.position;
        anchor.transform.rotation = previousImageTransform.rotation;
        AnchorDataTransfer.OnAnchorChange.Invoke();


        ResetCalibrationProgress();
        progressBar.TurnOffProgressBar();
        calibrationText.enabled = false;
        calibrationText.text += "\n Calibration successful!";
        myARTrackedImageManager.enabled = false;

    }

    void ResetCalibrationProgress()
    {
        timeOfCalibrationProgress = 0;
        targetMarker.gameObject.SetActive(false);
        targetMarker = null;
        progressBar.UpdateProgressBar(timeOfCalibrationProgress, timeOfFullCalibration);
        
    }
}
