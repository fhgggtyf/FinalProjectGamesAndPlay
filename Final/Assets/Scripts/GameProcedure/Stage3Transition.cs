using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Transition : MonoBehaviour
{
    public GameObject timer;

    public Stage3GameProcedure Scene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Clone"))
        {
            Debug.Log("LOL");
            timer.GetComponent<Timer>().mult *= 2;
            Scene.PlayerPrefab = Scene.Player;
            Scene.PlayerPrefabFollow = Scene.PlayerFollow;
            collision.gameObject.SetActive(false);
            Scene.cam.player = Scene.Player.GetComponent<Player>();
            Scene.followCam.Follow = Scene.PlayerFollow.transform;
        }


    }
}