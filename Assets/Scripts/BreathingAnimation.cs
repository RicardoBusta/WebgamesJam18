using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingAnimation : MonoBehaviour
{
    public float breathingSpeed;
    public float breathingAmplitudeY;
    public float breathingAmplitudeX;

    private float angle;
    
    private void Update()
    {
        angle += breathingSpeed * Time.deltaTime;
        var sin = Mathf.Sin(angle);
        var cos = Mathf.Cos(angle);
        transform.localScale = new Vector3(1  + cos * breathingAmplitudeX, 1 + sin * breathingAmplitudeY, 1 + cos * breathingAmplitudeX);
    }
}