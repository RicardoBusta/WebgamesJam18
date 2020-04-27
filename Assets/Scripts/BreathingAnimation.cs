using UnityEngine;

public class BreathingAnimation : MonoBehaviour
{
    private float angle;
    public float breathingAmplitudeX;
    public float breathingAmplitudeY;
    public float breathingSpeed;

    private void Update()
    {
        angle += breathingSpeed * Time.deltaTime;
        var sin = Mathf.Sin(angle);
        var cos = Mathf.Cos(angle);
        transform.localScale = new Vector3(1 + cos * breathingAmplitudeX, 1 + sin * breathingAmplitudeY,
            1 + cos * breathingAmplitudeX);
    }
}