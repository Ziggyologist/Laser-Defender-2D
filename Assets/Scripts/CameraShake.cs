using System;
using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeMagnitude = 0.25f;

    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)UnityEngine.Random.insideUnitCircle * shakeMagnitude;
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = initialPosition; // Reset position after shaking
    }
}
