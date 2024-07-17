using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsSystem : MonoBehaviour
{
    [Header("System from lifeSystems")]
    public TakerAllLiferSystems System;

    [Header("Potions Settings")]
    public float AmountOfPotions = 3;
    public float MaxAmountOfPotions = 3;
    public int AmountOfHeal = 20;

    [Header("Timer")]
    public float TimerWhenStartNextHeal = 5f;
    public float MaxTime = 5f;

    [HideInInspector] public bool IsPressed;

    public void NormalHeal(GameObject HealableObject)
    {
        IHealable IHealableObject = HealableObject.GetComponent<IHealable>();
        if (IHealableObject != null)
        {
            IHealableObject.Heal(AmountOfHeal);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MaxTime = TimerWhenStartNextHeal;
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Healther() != System.GetHealthDefault())
        {
            UsePlayer();
        }
        else
        {
            IsPressed = false;
        }
    }

    public void UsePlayer()
    {
        
        if (Input.GetKey(KeyCode.H))
        {
            IsPressed = true;
            if (MaxAmountOfPotions != 0 && AmountOfPotions != 0)
            {
                IsPressed = true;
                ReceiveHeal();
            }
            else
            {
                IsPressed = false;
            }    
        }
        else
        {
            IsPressed = false;
            TimerWhenStartNextHeal = MaxTime;
        }
    }

    private void ReceiveHeal()
    {
        TimerWhenStartNextHeal -= Time.deltaTime;
        if (TimerWhenStartNextHeal <= 0)
        {
            NormalHeal(this.gameObject);
            AmountOfPotions = AmountOfPotions - 1;
            TimerWhenStartNextHeal = MaxTime;
        }
    }
}
