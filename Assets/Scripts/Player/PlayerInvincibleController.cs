using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibleController : MonoBehaviour
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private Color color;

    [SerializeField]
    private int nof;

    private InvincibilityController invincibility;
    private void Awake()
    {
        invincibility=GetComponent<InvincibilityController>();
    }
    public void StartInvincibility()
    {
        invincibility.StartInvincibility(duration,color,nof);
    }
}
