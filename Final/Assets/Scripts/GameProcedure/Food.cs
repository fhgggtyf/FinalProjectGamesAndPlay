using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Stats data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Stats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBase"))
        {
            data.Health.Increase(10);
            data.healthInterface.AddToCurrentHealth(10);
        }
    }
}
