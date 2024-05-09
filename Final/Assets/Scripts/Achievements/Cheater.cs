using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheater : MonoBehaviour
{
    public GameObject AchievementGO;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBase"))
        {
            AchievementGO.SetActive(true);
        }
    }
}
