using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adder : MonoBehaviour
{
    public SequentialActivator ctx;

    private void Awake()
    {
        ctx = gameObject.transform.parent.GetComponent<SequentialActivator>();
    }

    private void OnDisable()
    {
        ctx.ActivateNext();
        ctx.ActivateNext();
    }
}
