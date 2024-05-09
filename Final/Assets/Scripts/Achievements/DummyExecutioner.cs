using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DummyExecutioner : MonoBehaviour
{
    public GameObject AchivementGO;

    [Inject] InGameData data;

    private void OnDisable()
    {
        if(AchivementGO != null)
        {
            AchivementGO.SetActive(true);
        }
    }
}
