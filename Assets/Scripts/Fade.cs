using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image fadeImage;

    public void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeIn(float duration)
    {
        Color start=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,1);
        Color end=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,0);
        yield return FadeCoroutine(start,end,duration);
        gameObject.SetActive(false);
    }

        public IEnumerator FadeOut(float duration)
    {
        Color start=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,0);
        Color end=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,1);
        gameObject.SetActive(true);
        yield return FadeCoroutine(start,end,duration);
    }

    public IEnumerator FadeCoroutine(Color startColor, Color endColor, float duration)
    {
        float elapsedTime=0;
        float elapsedPercentage=0;
        while(elapsedPercentage<1)
        {
            elapsedPercentage=elapsedTime/duration;
            fadeImage.color=Color.Lerp(startColor, endColor,elapsedPercentage);
            yield return null;
            elapsedTime+=Time.deltaTime;
        }
    }
}
