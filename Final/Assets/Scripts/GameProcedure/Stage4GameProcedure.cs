using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4GameProcedure : MonoBehaviour
{
    public PlayerData data;

    public AttackInitializer playerAtk;

    PlayerData storage;

    // Start is called before the first frame update
    void Start()
    {
        storage = data;
    }

    // Update is called once per frame
    void Update()
    {
        data.MaxSpeed -= data.MaxSpeed * 0.02f * Time.deltaTime;
        data.JumpHeight -= data.JumpHeight * 0.02f * Time.deltaTime;
        playerAtk.data.SetAmount(playerAtk.data.Amount - 0.1f * Time.deltaTime);
    }

    private void OnDestroy()
    {
        data = storage;
    }
}
