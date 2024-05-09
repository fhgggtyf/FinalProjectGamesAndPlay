using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameObject context;

    public bool hasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered)
        {
            context.GetComponent<Stage3GameProcedure>().RingEvent();
            hasTriggered = true;
        }
    }
}
