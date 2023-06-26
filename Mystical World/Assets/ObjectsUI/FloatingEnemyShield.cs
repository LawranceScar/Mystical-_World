using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingEnemyShield : MonoBehaviour
{
    [SerializeField] public Slider sliderShield;

    public void UpdateBar(float currentamount, float maxamount)
    {
        sliderShield.value = currentamount / maxamount;
    }
}
