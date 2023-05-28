using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLiferSystems : MonoBehaviour, IDamagable, IHealable
{
    [Header("Health Settings")]
    [SerializeField] protected float HealthPlayer = 100; // Скільки всього хп
    [SerializeField] protected float HealthHeal = 1; // Скільки буде лікуватися за одиницю часу
   // [SerializeField] protected float TimeToHeal = 4.0f; // Час лікування
   // [SerializeField] protected int NumberWhenHeal = 20; // Коли можна бути використати Heal
    [SerializeField] protected float WhenRespawn = 5.0f;

    [Header("Stamina Settings")]

    [SerializeField] protected int Stamina = 100; // Скільки всього стаміни 
    [SerializeField] protected int StaminaKiller = 1; // Скільки віднімається за раз
    [SerializeField] protected float TimerAmountKiller = 0.03f; // Скільки часу на перезарядку самої стаміни при використанні
    [SerializeField] protected float TimerRespawnStaminaAmount = 3.0f; // Скільки часу стаміна робить reload

    [Header ("Mp Settings")]
    [SerializeField] protected int Mana = 40;
    [SerializeField] protected int ManaKiller = 1;
    [SerializeField] protected int RespawnAmount = 10;
    [SerializeField] protected float TimerManaAmount = 0.03f;
    [SerializeField] protected float TimerRespawnManaAmount = 3.0f;

    // Не чіпати
   // [HideInInspector] public float DefaultHP;
   // [HideInInspector] public int DefaultStamina;
  //  [HideInInspector] public int DefaultMP;
    [HideInInspector] public int MpAmount; // Кількість мани
    [HideInInspector] public int StaminaAmount; // Кількість стаміни
    [HideInInspector] public float Health; // Кількість ХП

    private float DefaultTimerRespawn;
    private float DefaultTimerAmount;
    private float DefaultTimerManaKiller;
    private float DefaultTimerManaRespawn;
    private float DefaultWhenRespawn;

    // не чіпати
    private bool IsStartedStamina;
    private bool IsStartedMp;

    public static bool IsDead; // Якщо смерть

    public void TakerDamage(float damage)
    {
      Health = Health - damage;
    }
    public void Heal(float heal)
    {
        if (IsDead == false)
        {
                Health = Health + heal;
        }
    }

    void Start()
    {
        DefaultWhenRespawn = WhenRespawn;
        DefaultTimerManaKiller = TimerManaAmount;
        DefaultTimerManaRespawn = TimerRespawnManaAmount;
        DefaultTimerAmount = TimerAmountKiller;
        DefaultTimerRespawn = TimerRespawnStaminaAmount;
        StaminaAmount = Stamina;
        Health = HealthPlayer;
        MpAmount = Mana;
      //  DefaultHP = Health;
      //  DefaultStamina = StaminaAmount;
       // DefaultMP = MpAmount;
    }

    void Update()
    {
        // Debug.Log(DefaultStaminaAmount);
        StaminaCounter();
        HealthFunc();
        ManaSystem();
    }

    

    private void StaminaCounter()
    {
        if (IsDead == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    TimerAmountKiller -= Time.deltaTime;
                  //  Debug.Log(TimerAmountKiller);
                    // Debug.Log(TimerAmount);
                    if (TimerAmountKiller <= 0)
                    {
                        StaminaAmount = StaminaAmount - StaminaKiller;
                        TimerAmountKiller = DefaultTimerAmount;
                      //  Debug.Log(StaminaAmount);
                    }
                    IsStartedStamina = true;
                }
            }
            else
            {
                TimerAmountKiller = DefaultTimerAmount;
                IsStartedStamina = false;
            }

            if (StaminaAmount != Stamina && IsStartedStamina == false)
            {
                TimerRespawnStaminaAmount -= Time.deltaTime;
                if (TimerRespawnStaminaAmount <= 0)
                {
                    StaminaAmount = StaminaAmount + StaminaKiller;
                    TimerRespawnStaminaAmount = DefaultTimerRespawn;
                }
                //   Debug.Log(TimerRespawnStaminaAmount);
            }

            if (StaminaAmount < 0)
            {
                StaminaAmount = 0;
            }
            if (StaminaAmount > Stamina)
            {
                StaminaAmount = Stamina;
            }
        }
        else
        {
            StaminaAmount = Stamina;
        }

      //  Debug.Log(StaminaAmount);
    }

    private void HealthFunc()
    {
        Die();

        if (Health > HealthPlayer)
        {
            Health = HealthPlayer;
        }

        if (Health < 0)
        {
            Health = 0;
        }

        if (IsDead == true)
        {
            WhenRespawn -= Time.deltaTime;
            if (WhenRespawn <= 0)
            {

                    IsDead = false;
                    Health = HealthPlayer;
                    WhenRespawn = DefaultWhenRespawn;
            }
        }
      /*  if (Health <= NumberWhenHeal)
        {
            TimeToHeal -= Time.deltaTime;
            if (TimeToHeal <= 0)
            {
                Health = Health + HealthHeal;
            }
        } */
    }

    private void Die()
    {
        if (Health <= 0)
        {
            IsDead = true;
        }
        else
        {
            IsDead = false;
        }
    }

    private void ManaSystem()
    {
        if (IsDead == false)
        {
          /*  if (Input.GetKey(KeyCode.LeftShift))
            {
                TimerManaAmount -= Time.deltaTime;
                if (TimerManaAmount <= 0)
                {
                    MpAmount = MpAmount - ManaKiller;
                    TimerManaAmount = DefaultTimerManaKiller;
                }
                IsStartedMp = false;
            }
            else
            {
                IsStartedMp = true;
                if (IsStartedMp == true && MpAmount < Mana)
                {
                    TimerRespawnManaAmount -= Time.deltaTime;
                    if (TimerRespawnManaAmount <= 0)
                    {
                        if (IsStartedMp == true)
                        {
                            MpAmount = MpAmount + RespawnAmount;
                            TimerRespawnManaAmount = DefaultTimerManaRespawn;
                        }
                        //  Debug.Log(MpAmount);
                    }
                } */

            if (MpAmount < 0)
            {
                MpAmount = 0;
            }
        }
        else
        {
            MpAmount = Mana;
        }
        if (MpAmount > Mana)
        {
            MpAmount = Mana;
        }

        
    }
}
