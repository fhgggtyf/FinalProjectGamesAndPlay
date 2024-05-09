using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialActivator : MonoBehaviour
{
    public List<GameObject> gameObjectsToActivate; // Assign this in the Inspector

    public GameObject target;
    private int currentIndex = 0; // To keep track of which GameObject to activate next

    private void Start()
    {
        ActivateNext();
    }

    public void ActivateNext()
    {
        if (currentIndex < gameObjectsToActivate.Count)
        {
            GameObject objToActivate = gameObjectsToActivate[currentIndex];
            if (objToActivate != null)
            {
                objToActivate.GetComponentInChildren<Shooter>()._parent = target;
                objToActivate.SetActive(true);
                currentIndex++; // Increment so the next call activates the next GameObject
            }
        }
        else
        {
            Debug.Log("All GameObjects have been activated.");
        }
    }
}
