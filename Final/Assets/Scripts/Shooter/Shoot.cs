using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public List<GameObject> Shooters;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Shooters.Capacity/2; i++)
        {
            Shooters[i].transform.position = new Vector3(transform.position.x + 17, transform.position.y + Random.Range(-20, 40), transform.position.z);
        }
        for (int i = Shooters.Capacity/2; i < Shooters.Capacity; i++)
        {
            Shooters[i].transform.position = new Vector3(transform.position.x - 17, transform.position.y + Random.Range(-20, 40), transform.position.z);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
