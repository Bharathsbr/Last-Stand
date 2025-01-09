using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text=GetComponent<TMP_Text>();
    }

    public void ScoreUpdate(Score score)
    {
        text.text = $"Score:{score.score}";
    }
}
