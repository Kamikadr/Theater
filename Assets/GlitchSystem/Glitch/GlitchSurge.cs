using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;
using Sirenix.OdinInspector;

public class GlitchSurge : MonoBehaviour
{
    [SerializeField]
    AnalogGlitch analogGlitch;

    [SerializeField]
    float surgeTime = 0.5f;

    [SerializeField]
    [MinMaxSlider(0f, 1f)]
    public Vector2 JitterDiapason = Vector2.zero;
    [SerializeField]
    [MinMaxSlider(0f, 1f)]
    public Vector2 JumpDiapason = Vector2.zero;
    [SerializeField]
    [MinMaxSlider(0f, 1f)]
    public Vector2 ShakeDiapason = Vector2.zero;
    [SerializeField]
    [MinMaxSlider(0f, 1f)]
    public Vector2 ColorDriftDiapason = Vector2.zero;

    void Start()
    {
        if (analogGlitch == null)
            analogGlitch = GetComponent<AnalogGlitch>();
    }

    [Button("Surge")]
    public void Surge()
    {
        analogGlitch.enabled = true;
        StartCoroutine("SurgeCoroutine");
    }

    IEnumerator SurgeCoroutine()
    {
        float timeElapsed = 0f;
        float glitchSurgeChangeInterval = Mathf.Clamp(surgeTime / 10, 0.1f, surgeTime / 10);
        
        while (timeElapsed < surgeTime)
        {
            SetupRandomGlitchValues();
            yield return new WaitForSeconds(glitchSurgeChangeInterval);
            timeElapsed += glitchSurgeChangeInterval;
        }
        GlitchValuesReset();
        analogGlitch.enabled = false;
    }

    void SetupRandomGlitchValues()
    {
        analogGlitch.scanLineJitter = Random.Range(JitterDiapason.x, JitterDiapason.y);
        analogGlitch.verticalJump = Random.Range(JumpDiapason.x, JumpDiapason.y);
        analogGlitch.horizontalShake = Random.Range(ShakeDiapason.x, ShakeDiapason.y);
        analogGlitch.colorDrift = Random.Range(ColorDriftDiapason.x, ColorDriftDiapason.y);
    }

    void GlitchValuesReset()
    {
        analogGlitch.scanLineJitter = 0f;
        analogGlitch.verticalJump = 0f;
        analogGlitch.horizontalShake = 0f;
        analogGlitch.colorDrift = 0f;
    }
}
