using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILifeSystems : MonoBehaviour
{
    public TakerAllLiferSystems SystemAller;
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
        StartMax();
        StaminaAndHealthBarSystem();
        MpSystem();
        ColourChange();
        DeathUI();
        DisableAllHudWhenDie();
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
            Debug.Log("Jaaaaa");
            Debug.Log(MaxStaminaAmount);
        }
        else
        {
            StaminaBar.fillAmount = MaxStaminaAmount;
            Debug.Log("Here");
            Debug.Log(StaminaAmount);
            Debug.Log(MaxStaminaAmount);

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
