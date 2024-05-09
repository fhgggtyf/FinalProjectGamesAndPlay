using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePrefab : MonoBehaviour
{
    public List<GameObject> topGameObjects;
    public List<GameObject> botGameObjects;

    public GameObject topObject, botObject;

    int topRandom, botRandom;

    // Start is called before the first frame update
    void Start()
    {
        do
        {
            topRandom = Random.Range(0, 4);
            botRandom = Random.Range(0, 4);
        } while (topRandom == botRandom);

        topObject = topGameObjects[topRandom];
        botObject = botGameObjects[botRandom];

        topObject.SetActive(true);
        botObject.SetActive(true);

        topObject.GetComponent<Stage4ChoiceObject>().SetOtherChoice(botObject);
        botObject.GetComponent<Stage4ChoiceObject>().SetOtherChoice(topObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
