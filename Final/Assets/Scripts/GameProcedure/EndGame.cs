using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using TMPro;
using Zenject;

public class EndGame : MonoBehaviour
{

    [Inject] InGameData data;

    public PlayerData playerData;

    public TMP_Text scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.text = data.points.ToString();
        data.points = 0;
        data.MAXHEALTH = 100;
        data.currentStage = 0;
        data.health = 100;
        data.cutBookCounter = 0;

        playerData.MaxSpeed = 8;
        playerData.JumpHeight = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
