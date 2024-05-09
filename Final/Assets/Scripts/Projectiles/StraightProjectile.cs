using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : MonoBehaviour
{
    float initialVelocity;

    float time = 0;

    public float destroyTimeThreshold = 5;

    Vector3 targetPoint;

    bool accTriggered = false;

    void Start()
    {
        initialVelocity = Random.Range(7,10);
    }

    public void SetLookAtPoint(Vector3 point)
    {
        targetPoint = point;
    }

    void Update()
    {
        if (!accTriggered)
        {
            // Get the Rigidbody component
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.gravityScale = 0;

            if (rb != null)
            {
                Vector2 direction = (targetPoint - transform.position).normalized;

                // Apply initial velocity in the direction of the target point
                rb.velocity = direction * initialVelocity;

                accTriggered = true;
            }
            else
            {
                Debug.LogWarning("Rigidbody component is missing from this GameObject.");
            }
        }
        // Check if the GameObject's y-coordinate is below the threshold
        if (time > destroyTimeThreshold)
        {
            Destroy(gameObject); // Destroy the GameObject
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}