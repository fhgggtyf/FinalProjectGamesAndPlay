using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneSwitch : MonoBehaviour
{
    [Inject] InGameData data;
    public void Proceed()
    {
        Debug.Log(data.currentStage + 1);
        SceneManager.LoadSceneAsync(data.currentStage + 1);
        data.currentStage++;
    }
}
