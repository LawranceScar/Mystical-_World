using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSlots : MonoBehaviour
{
    [SerializeField]public GameObject Weapon1;
    [SerializeField]public GameObject Weapon2;
    [SerializeField]public GameObject Weapon3;
    [SerializeField]public GameObject Weapon4;

    public static GameObject WeaponSe;

    public static bool WeaponF = false;
    public static bool WeaponS = true;
    public static bool WeaponT = false;
    public static bool WeaponFo = false;

    void Start()
    {
        Weapon1.SetActive(false);
        Weapon2.SetActive(true);
        Weapon3.SetActive(false);
        Weapon4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject WeaponSe = Weapon2;

            if (Input.GetKeyDown(KeyCode.F1))
            {
                WeaponF = true;
                WeaponS = false;
                WeaponT = false;
                WeaponFo = false;
                Weapon1.SetActive(true);
                Weapon2.SetActive(false);
                Weapon3.SetActive(false);
                Weapon4.SetActive(false);
            }
        

            if (Input.GetKeyDown(KeyCode.F2))
            {
                WeaponF = false;
                WeaponS = true;
                WeaponT = false;
                WeaponFo = false;

                Weapon1.SetActive(false);
                Weapon2.SetActive(true);
                Weapon3.SetActive(false);
                Weapon4.SetActive(false);
            }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            WeaponF = false;
            WeaponS = false;
            WeaponT = true;
            WeaponFo = false;

            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
            Weapon4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            WeaponF = false;
            WeaponS = false;
            WeaponT = false;
            WeaponFo = true;

            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
            Weapon4.SetActive(true);
        }
        }
    }
