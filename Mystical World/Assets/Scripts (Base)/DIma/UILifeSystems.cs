using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILifeSystems : MonoBehaviour
{
    public TakerAllLiferSystems SystemAller;
    public PotionsSystem potionsSystem;
    [Header ("Change UI")]
    public Image StaminaBar;
    public Image HealthBar;
    public TMP_Text StaminaText;
    public Image MpBar;
    public Image MpBarConture;

    [Header ("Hide/Show Image HUD")]
    public Image[] AllHudUI;
    public TMP_Text[] AllTextUI;

    [Header ("Death screen")]
    public TMP_Text DeathText;
    public Image DeathScreen;
    public Animator ANimator;
    public string AnimationCheck;

    [Header("Potions UI")]
    public TMP_Text AmountOfPotions;
    public Image TimeRadialPotion;
    public Image BackTimeRadialPotion;
    public TMP_Text TimeText;

    private float StaminaAmount;
    private float Health;
    private float MpAmount;
    private float MaxMpAmount;
    private float MaxHealth;
    private float MaxStaminaAmount;

    

    [Header  ("Smooth")]
    public float LerpSpeed;

    void Start()
    {
        DeathText.enabled = true;
        // DeathScreen.text = " ";
    }

    private void StartMax()
    {
        MaxHealth = SystemAller.GetHealthDefault();
        MaxStaminaAmount = SystemAller.GetStaminaDefault();
        MaxMpAmount = SystemAller.GetMperDefault();
        
    }

    void Update()
    {
        DisableAllHudWhenDie();
        if (!AllLiferSystems.IsDead)
        {
            StartMax();
            StaminaAndHealthBarSystem();
            MpSystem();
            ColourChange();
            PotionsUI();
            ShowHidePotionsUI();
        }
        else
        {

            DeathUI();
        }
       // Check();
    }

    private void ColourChange()
    {
        Color staminaColour = Color.Lerp(Color.red, SetColour(60, 123, 238, 255), StaminaAmount / MaxStaminaAmount);
        Color HealthColour = Color.Lerp(Color.red, SetColour(238, 96, 60, 255), Health / MaxHealth);
        Color MpBarColour = Color.Lerp(Color.red, SetColour(32, 140, 255, 255), MpAmount / MaxMpAmount);
        StaminaBar.color = staminaColour;
        HealthBar.color = HealthColour;
        MpBarConture.color = MpBarColour;
    }

    private Color SetColour(byte R, byte G, byte B, byte A)
    {
        Color color = new Color32(R, G, B, A);
        return color;
    }

    private void DeathUI()
    {
        if (AllLiferSystems.IsDead == true)
        {
            Color death = SetColour(0, 0, 0, 200);
            DeathScreen.color = death;
        }
        else
        {
            Color death = SetColour(0, 0, 0, 0);
            DeathScreen.color = death;
        }
    }

    private void StaminaAndHealthBarSystem()
    {
        Health = SystemAller.Healther();
        StaminaAmount = SystemAller.Staminer();
        StaminaText.text = StaminaAmount.ToString() + "%";
        if (StaminaAmount != MaxStaminaAmount)
        {
            StaminaBar.fillAmount = Mathf.Lerp(StaminaBar.fillAmount, StaminaAmount / MaxStaminaAmount, LerpSpeed);
            //Debug.Log(StaminaBar.fillAmount);
           // Debug.Log("Jaaaaa");
           // Debug.Log(MaxStaminaAmount);
        }
        else
        {
            StaminaBar.fillAmount = MaxStaminaAmount;
           // Debug.Log("Here");
           // Debug.Log(StaminaAmount);
           // Debug.Log(MaxStaminaAmount);

        }

        if (Health != MaxHealth)
        {
            if (Health != 0)
            {
               // Debug.Log("я тут");
                HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, Health / MaxHealth, LerpSpeed);
                StaminaBar.enabled = true;
                HealthBar.enabled = true;
            }
            else
            {
                HealthBar.fillAmount = MaxHealth;
            }
           // Debug.Log("јга");
        }
        else
        {
                Health = MaxHealth;
                HealthBar.fillAmount = MaxHealth;
          //  Debug.Log("“ут111");
        }
      // Debug.Log(Health);
    }

    private void PotionsUI()
    {
        AmountOfPotions.text = potionsSystem.AmountOfPotions.ToString();
        if (potionsSystem.TimerWhenStartNextHeal != 0)
        {
            TimeRadialPotion.fillAmount = Mathf.Lerp(TimeRadialPotion.fillAmount, potionsSystem.TimerWhenStartNextHeal / potionsSystem.MaxTime, 10);
            TimeText.text = potionsSystem.TimerWhenStartNextHeal.ToString("0.00");
        }

        if (potionsSystem.AmountOfPotions < potionsSystem.MaxAmountOfPotions && potionsSystem.AmountOfPotions != 1 && potionsSystem.AmountOfPotions != 0)
        {
            AmountOfPotions.color = Color.Lerp(Color.yellow, SetColour(255, 133, 40, 255), potionsSystem.AmountOfPotions / potionsSystem.MaxAmountOfPotions);
        }
        else if (potionsSystem.AmountOfPotions == 1 || potionsSystem.AmountOfPotions == 0)
        {
            AmountOfPotions.color = SetColour(255, 72, 40, 255);
        }
    }

    private void ShowHidePotionsUI()
    {
        if (potionsSystem.IsPressed)
        {
            TimeRadialPotion.enabled = true;
            TimeText.enabled = true;
            BackTimeRadialPotion.enabled = true;
        }
        else
        {
            TimeRadialPotion.enabled = false;
            TimeText.enabled = false;
            BackTimeRadialPotion.enabled = false;
        }
    }

    private void MpSystem()
    {
        MpAmount = SystemAller.Mper();
        if (MpAmount != MaxMpAmount)
        {
           MpBar.fillAmount = Mathf.Lerp(MpBar.fillAmount, MpAmount / MaxMpAmount, LerpSpeed);
            //Debug.Log(StaminaBar.fillAmount);
        }
        else
        {
            MpAmount = MaxMpAmount;
            MpBar.fillAmount = MaxMpAmount;
        }
    }

    private void DisableAllHudWhenDie()
    {
        if (AllLiferSystems.IsDead == false)
        {
            ParameterAllHide(AllHudUI, AllTextUI, true);

            DeathText.enabled = false;
          //  ANimator.enabled = false;
            // ANimator.SetBool(AnimationCheck, false);
        }
        else
        {
            ParameterAllHide(AllHudUI, AllTextUI, false);
          //  ANimator.enabled = true;
            DeathText.enabled = true;
           // ANimator.SetBool(AnimationCheck, true);
        }
    }

    private void ParameterAllHide(Image[] image, TMP_Text[] text, bool type)
    {
        if (image != null)
        {
            for (int i = 0; i < image.Length; i++)
            {
                image[i].enabled = type;
            }
        }
        else
        {
            Debug.LogError("Null image massive[] in your script!");
        }

            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    text[i].enabled = type;
                }
            }
            else
        {
            Debug.LogError("Null text massive[] in your script!");
        }

        return;
    }
}
