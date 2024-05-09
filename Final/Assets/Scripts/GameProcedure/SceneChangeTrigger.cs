using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger : MonoBehaviour
{
    public GameObject SwitchSceneObject;

    private bool hasIncremented = false;

    public bool needInteraction = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (needInteraction)
        {
            if (collision.CompareTag("PlayerBase") && Input.GetKey(KeyCode.K) && !hasIncremented)
            {
                SwitchSceneObject.GetComponent<SceneSwitch>().Proceed();
                hasIncremented = true;
            }
        }
        else
        {
            if (collision.CompareTag("PlayerBase") && !hasIncremented)
            {
                SwitchSceneObject.GetComponent<SceneSwitch>().Proceed();
                hasIncremented = true;
            }
        }
    }
}
