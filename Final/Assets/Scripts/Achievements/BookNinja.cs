using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BookNinja : MonoBehaviour
{

    public GameObject AchievementGO;

    [Inject]
    public InGameData data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (data.cutBookCounter >= 20)
        {
            AchievementGO.SetActive(true);
        }
    }
}
