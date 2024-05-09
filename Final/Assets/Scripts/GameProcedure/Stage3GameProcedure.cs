using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Cinemachine;

public class Stage3GameProcedure : MonoBehaviour
{

    public GameObject Coworker;
    public GameObject Ring;

    public GameObject timer;

    public GameObject PlayerPrefab;
    public GameObject Player;

    public GameObject PlayerPrefabFollow;
    public GameObject PlayerFollow;

    public CameraManager cam;

    public CinemachineVirtualCamera followCam;

    private bool ringEventActive, coworkerEventActive;

    // Start is called before the first frame update
    void Start()
    {
        ringEventActive = false;
        coworkerEventActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ringEventActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cam.player = PlayerPrefab.GetComponent<Player>();
                followCam.Follow = PlayerPrefabFollow.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                cam.player = Player.GetComponent<Player>();
                followCam.Follow = PlayerFollow.transform;
            }
        }

    }

    public void RingEvent()
    {
        ringEventActive = true;
        PlayerPrefab.SetActive(true);
    }

    public void CoWEvent()
    {
        coworkerEventActive = true;
        timer.GetComponent<Timer>().timeLeft -= 90;
        timer.GetComponent<Timer>().mult *= 3;
    }
}
