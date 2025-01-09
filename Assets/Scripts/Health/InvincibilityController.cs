using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController;
    private FlashSprite flashSprite;
    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        flashSprite = GetComponent<FlashSprite>();
    }

    public void StartInvincibility(float duration,Color color,int nof)
    {
        StartCoroutine(Invincible(duration,color,nof)); 
    }

    private IEnumerator Invincible(float duration,Color color,int nof)
    {
        healthController.isInvincible=true;
        yield return flashSprite.Flash(duration,color,nof);
        healthController.isInvincible=false;
    }
}
