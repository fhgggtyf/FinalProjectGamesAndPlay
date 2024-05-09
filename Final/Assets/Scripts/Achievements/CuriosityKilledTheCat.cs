using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuriosityKilledTheCat : MonoBehaviour
{
    public GameObject AchievementGO;
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D()
    {
        if (!AchievementGO.activeInHierarchy)
        {
            AchievementGO.SetActive(true);
            obstacle.SetActive(true);
        }

    }

}
