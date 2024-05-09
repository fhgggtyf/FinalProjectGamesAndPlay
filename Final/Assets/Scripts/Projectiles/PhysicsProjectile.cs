using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProjectile : MonoBehaviour
{
    public float initialVelocity = 10f;
    public float destroyYThreshold = -50f;

    Vector3 targetPoint;

    bool accTriggered = false;

    void Start()
    {

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
        if (transform.position.y < destroyYThreshold)
        {
            Destroy(gameObject); // Destroy the GameObject
        }
    }
}
