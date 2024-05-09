using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class Timer : MonoBehaviour
{
    [Inject] InGameData data;

    public TMP_Text text;

    public TMP_Text multText;

    public int mult = 1;

    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 300f;
        text.text = timeLeft.ToString() + "S";
        text.outlineColor = Color.black;
        text.outlineWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (mult != 1)
        {
            multText.text = "X " + mult.ToString();
        }
        timeLeft -= Time.deltaTime;
        text.text = timeLeft.ToString("F2") + "S";
        if (timeLeft >= 50)
        {
            text.color = Color.green;
        }
        else if (timeLeft >= 0)
        {
            text.color = Color.black;
        }
        else
        {
            text.color = Color.red;
        }
    }

    private void OnDestroy()
    {
        data.points += mult * (int)timeLeft;
    }
}
