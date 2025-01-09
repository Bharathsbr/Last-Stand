using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplash : MonoBehaviour
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private Color color;
    [SerializeField]
    private int nof;

    private FlashSprite sprite;

    private void Awake()
    {
        sprite = GetComponent<FlashSprite>();
    }

    public void StartFlash()
    {
        sprite.StartFlash(duration, color,nof);
    }
}
