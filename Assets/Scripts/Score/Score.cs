using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public int score=0;
    public UnityEvent OnScoreChanged;
    public void AddScore(int point)
    {
        score+=point;
        OnScoreChanged.Invoke();
    }
}
