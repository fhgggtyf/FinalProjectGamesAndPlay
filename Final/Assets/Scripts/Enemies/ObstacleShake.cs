using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShake : MonoBehaviour
{
    private Vector3 originalPosition;
    public float vibrationIntensity = 0.1f;
    public float vibrationDuration = 0.2f;

    void OnEnable()
    {
        originalPosition = transform.position;
        StartCoroutine(Vibrate());
    }

    IEnumerator Vibrate()
    {
        float elapsedTime = 0;
        while (elapsedTime < vibrationDuration)
        {
            // Move GameObject to a new random position within a small range around the original position
            transform.position = originalPosition + (Random.insideUnitSphere * vibrationIntensity);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        // Reset the position to the original one after the vibration is done
        transform.position = originalPosition;
        this.enabled = false;
    }
}
