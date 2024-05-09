using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class Points : MonoBehaviour
{

    [Inject] InGameData data;

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Points:\n" + data.points.ToString();
    }
}
