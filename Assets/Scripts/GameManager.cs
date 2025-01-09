using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float wait;

    [SerializeField]
    private SceneController sceneController;

    public void PlayOnDie()
    {
        Invoke(nameof(EndGame),wait);
    }

    public void EndGame()
    {
        sceneController.LoadScene("MainMenu");
    }
}
