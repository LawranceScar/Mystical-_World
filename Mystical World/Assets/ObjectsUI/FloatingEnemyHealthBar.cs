using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingEnemyHealthBar : MonoBehaviour
{
    [SerializeField] public Slider sliderHealth;

    public void UpdateBar(float currentamount, float maxamount)
    {
        sliderHealth.value = currentamount / maxamount;
    }
}
