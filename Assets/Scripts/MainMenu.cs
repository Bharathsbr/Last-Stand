using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneController sceneController;
    public void Play()
    {
        sceneController.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
