using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, height, startXPos, startYPos;
    public GameObject Camera;
    public float xparallaxEffect;
    public float yparallaxEffect;

    public bool xExtend, yExtend;

    // Start is called before the first frame update
    void Start()
    {
        startXPos = transform.position.x;
        startYPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xTemp = Camera.transform.position.x * (1 - xparallaxEffect);
        float yTemp = Camera.transform.position.y * (1 - yparallaxEffect);
        float xDist = Camera.transform.position.x * xparallaxEffect;
        float yDist = Camera.transform.position.y * yparallaxEffect;

        transform.position = new Vector3(startXPos + xDist, startYPos + yDist, transform.position.z);

        if (xExtend)
        {
            if (xTemp > startXPos + length)
            {
                startXPos += length;
            }
            else if (xTemp < startXPos - length)
            {
                startXPos -= length;
            }
        }
        if (yExtend)
        {
            if (yTemp > startYPos + height)
            {
                startYPos += height;
            }
            else if (yTemp < startYPos - height)
            {
                startYPos -= height;
            }
        }


    }
}
