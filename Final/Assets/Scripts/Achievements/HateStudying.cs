using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HateStudying : MonoBehaviour
{

    public List<GameObject> gameObjects;

    public GameObject AchievementGO;

    private bool allDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        allDisabled = (!gameObjects[0].activeInHierarchy) && (!gameObjects[1].activeInHierarchy) && (!gameObjects[2].activeInHierarchy);

        if (allDisabled)
        {
            AchievementGO.SetActive(true);
        }

    }
}
