using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void StartFlash(float duration,Color color,int nof)
    {
        StartCoroutine(Flash(duration,color,nof));
    }
    public IEnumerator Flash(float duration,Color color,int numberOfFlashes)
    {
        Color startcolor=spriteRenderer.color;
        float elapsedTime=0;
        float elapsedTimePercentage=0;
        while(elapsedTime<duration)
        {
            elapsedTime+=Time.deltaTime;
            elapsedTimePercentage=elapsedTime/duration;
            if(elapsedTimePercentage>1)
            {
                elapsedTimePercentage=1;
            }
            float pp=Mathf.PingPong(elapsedTimePercentage*2*numberOfFlashes,1);
            spriteRenderer.color=Color.Lerp(startcolor,color,pp);
            yield return null;

        }
    }
}
