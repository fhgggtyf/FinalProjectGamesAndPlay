using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSweetHome : MonoBehaviour
{
    public Timer timer;
    public GameObject AchievementGO;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.timeLeft <= 0 && player.transform.position.y <= 0)
        {
            AchievementGO.SetActive(true);
        }
        
    }
}
