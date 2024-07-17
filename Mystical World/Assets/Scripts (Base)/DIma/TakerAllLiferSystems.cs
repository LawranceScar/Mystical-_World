using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakerAllLiferSystems : AllLiferSystems
{

    public float GetHealthDefault()
    {
        //  DefaultHP = Health;
       // Debug.Log(Health);
        return HealthPlayer;
    }

    public int GetStaminaDefault()
    {
        return Stamina;
    }

    public int GetMperDefault()
    {
     //   DefaultMP = MpAmount;
        return Mana;
    }

    public float Healther()
    {
        return Health;
    }
    public int Staminer()
    {
        return StaminaAmount;
    }
    public int Mper()
    {
        return MpAmount;
    }
}
