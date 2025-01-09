using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private float duration;
    private Fade fade;

    private void Awake()
    {
        fade = GetComponentInChildren<Fade>();
    }

    public IEnumerator Start()
    {
        yield return fade.FadeIn(duration);
    }

    public void LoadScene(string name)
    {
        StartCoroutine(LoadCoroutine(name));
    }
    public IEnumerator LoadCoroutine(string name)
    {
        yield return fade.FadeOut(duration);
        yield return SceneManager.LoadSceneAsync(name);
    }
}
