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

    public void Exit()
    {
        // Log message to confirm quitting (useful for debugging)
        Debug.Log("Application exit requested");

        // Application.Quit() has no effect in the editor or in web builds
        Application.Quit();

        // To also ensure it stops playing in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
