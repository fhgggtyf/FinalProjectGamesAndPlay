using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gym : MonoBehaviour
{
    public AttackInitializer data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("PlayerBase").GetComponentInChildren<AttackInitializer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBase"))
        {
            data.data.SetAmount(data.data.Amount + 1);
        }
    }
}
