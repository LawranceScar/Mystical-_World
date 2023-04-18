using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakerAllLiferSystems : AllLiferSystems
{

    public float GetHealthDefault()
    {
      //  DefaultHP = Health;
        return DefaultHP;
    }

    public int GetStaminaDefault()
    {
        return DefaultStamina;
    }

    public int GetMperDefault()
    {
     //   DefaultMP = MpAmount;
        return DefaultMP;
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
