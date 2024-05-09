using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCreator : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 14; i++)
        {
            Instantiate(prefab, new Vector3(transform.position.x + i * 50, transform.position.y, transform.position.z), transform.rotation, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
