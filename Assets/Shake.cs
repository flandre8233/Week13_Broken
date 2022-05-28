using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    Transform Transform;
    // How long the object should shake for.
    float shakeDuration = 0f;
    // Amplitude of the shake. A larger value shakes the camera harder.
    float shakeAmount = 0.7f;
    float OriginalAmount = 0f;
    float OriginalDuration = 0f;
    float decreaseFactor = 1.0f;
    Vector3 originalPos;

    public void StartShake(float _shakeDuration, float _shakeAmount)
    {
        shakeDuration = _shakeDuration;
        shakeAmount = _shakeAmount;
        OriginalAmount = shakeAmount;
        OriginalDuration = _shakeDuration;
    }

    void Awake()
    {
        Transform = transform;
    }

    void Update()
    {
        if (IsShakeEnd())
        {
            ResetCamToNormal();
            return;
        }
        Transform.localPosition = originalPos + (Transform.rotation * Random.insideUnitCircle) * shakeAmount;
        shakeDuration -= Time.deltaTime * decreaseFactor;
        shakeAmount = Mathf.Lerp(OriginalAmount, 0, GetDurationLeftProgress());
    }

    bool IsShakeEnd()
    {
        return (shakeDuration <= 0);
    }

    float GetDurationLeftProgress()
    {
        return 1 - (shakeDuration / OriginalDuration);
    }

    void ResetCamToNormal()
    {
        shakeAmount = 0f;
        shakeDuration = 0f;
        Transform.localPosition = new Vector3();
    }
}
