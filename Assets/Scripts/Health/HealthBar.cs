using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foreGround;

    public void ChangeHealthBar(HealthController healthController)
    {
        foreGround.fillAmount=healthController.RemainingHealthPer;
    }
}
