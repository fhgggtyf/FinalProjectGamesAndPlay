using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivement : MonoBehaviour
{
    private Vector3 originalPosition;

    void OnEnable()
    {
        originalPosition = transform.position; // Store the original position
        StartCoroutine(MoveDownAndUp());
    }

    IEnumerator MoveDownAndUp()
    {
        // Move down 100 units over 2 seconds
        Vector3 targetPosition = originalPosition - new Vector3(0, 150, 0);
        yield return MoveToPosition(targetPosition, 1);

        // Wait at the bottom for 2 seconds
        yield return new WaitForSeconds(2);

        // Move back to the original position over 2 seconds
        yield return MoveToPosition(originalPosition, 2);
    }

    IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, target, time / duration);
            time += Time.deltaTime;
            yield return null; // Leave the frame and continue next frame
        }

        transform.position = target; // Ensure it ends exactly at the target
    }
}
