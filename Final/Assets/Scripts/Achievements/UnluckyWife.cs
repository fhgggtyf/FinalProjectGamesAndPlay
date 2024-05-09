using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnluckyWife : MonoBehaviour
{

    public GameObject cloneObject;

    public GameObject AchievementGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cloneObject.GetComponentInChildren<Stats>().healthInterface.CurrentHealth <= 0)
        {
            AchievementGO.SetActive(true);
        }
    }
}
