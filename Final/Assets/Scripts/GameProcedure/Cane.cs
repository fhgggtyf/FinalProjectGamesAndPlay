using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cane : MonoBehaviour
{
    public PlayerData data;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBase"))
        {
            data.JumpHeight += 1;
        }
    }
}
