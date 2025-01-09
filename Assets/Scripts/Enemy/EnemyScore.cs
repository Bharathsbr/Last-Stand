using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    private Score score;

    [SerializeField]
    private int point;

    private void Awake()
    {
        score=FindObjectOfType<Score>();
    }

    public void AddScore()
    {
        score.AddScore(point);
    }
}
