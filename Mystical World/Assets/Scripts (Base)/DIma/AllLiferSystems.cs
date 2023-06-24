using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLiferSystems : MonoBehaviour, IDamagable, IHealable, ISafeZonenable
{
    [Header("Health Settings")]
    [SerializeField] protected float HealthPlayer = 100; // ������ ������ ��
    [SerializeField] protected float HealthHeal = 1; // ������ ���� ��������� �� ������� ����
   // [SerializeField] protected float TimeToHeal = 4.0f; // ��� ��������
   // [SerializeField] protected int NumberWhenHeal = 20; // ���� ����� ���� ����������� Heal
    [SerializeField] protected float WhenRespawn = 5.0f;

    [Header("Stamina Settings")]

    [SerializeField] protected int Stamina = 100; // ������ ������ ������ 
    [SerializeField] protected int StaminaKiller = 1; // ������ ��������� �� ���
    [SerializeField] protected float TimerAmountKiller = 0.03f; // ������ ���� �� ����������� ���� ������ ��� �����������
    [SerializeField] protected float TimerRespawnStaminaAmount = 3.0f; // ������ ���� ������ ������ reload

    [Header ("Mp Settings")]
    [SerializeField] protected int Mana = 40;
    [SerializeField] protected int ManaKiller = 1;
    [SerializeField] protected int RespawnAmount = 10;
    [SerializeField] protected float TimerManaAmount = 0.03f;
    [SerializeField] protected float TimerRespawnManaAmount = 3.0f;

    // �� ������
   // [HideInInspector] public float DefaultHP;
   // [HideInInspector] public int DefaultStamina;
  //  [HideInInspector] public int DefaultMP;
    [HideInInspector] public int MpAmount; // ʳ������ ����
    [HideInInspector] public int StaminaAmount; // ʳ������ ������
    [HideInInspector] public float Health; // ʳ������ ��

    private float DefaultTimerRespawn;
    private float DefaultTimerAmount;
    private float DefaultTimerManaKiller;
    private float DefaultTimerManaRespawn;
    private float DefaultWhenRespawn;

    // �� ������
    private bool IsStartedStamina;
    private bool IsStartedMp;
    private bool IsSafeZoneTrue;

    public static bool IsDead; // ���� ������

    public void TakerDamage(float damage)
    {
        if (!IsSafeZoneTrue)
        {
            Health = Health - damage;
        }
    }
    public void Heal(float heal)
    {
        if (IsDead == false)
        {
            if (Health <= HealthPlayer)
            {
                Health = Health + heal;
            }
        }
    }

    public void IsSafeZone(bool value)
    {
        IsSafeZoneTrue = value;
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
        Debug.Log("Bool " +IsSafeZoneTrue);
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
