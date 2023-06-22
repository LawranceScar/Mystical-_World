using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSlots : MonoBehaviour
{
    [SerializeField]public GameObject Weapon1;
    [SerializeField]public GameObject Weapon2;
    [SerializeField]public GameObject Weapon3;
    [SerializeField]public GameObject Weapon4;
    [SerializeField] public GameObject UnpackWeapon1;
    [SerializeField] public GameObject UnpackWeapon2;
    [SerializeField] public GameObject UnpackWeapon3;
    [SerializeField] public GameObject UnpackWeapon4;
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
        Abud_Pistol mypistol = GetComponent<Abud_Pistol>();
        Abud mySwrod = GetComponent<Abud>();
        AbudLaser myLaser = GetComponent<AbudLaser>();
        Abud_Axe myaxe = GetComponent<Abud_Axe>();
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
        if (WeaponF == false)
        {
            mySwrod.TopSword.transform.SetParent(UnpackWeapon1.transform);
            mySwrod.TopSword.transform.localPosition = Vector3.zero;
        }
        else
        {
            mySwrod.TopSword.transform.SetParent(Weapon1.transform);
            mySwrod.TopSword.transform.localPosition = Vector3.zero;
        }
        if (WeaponS == false)
        {
            mypistol.TopPistol.transform.SetParent(UnpackWeapon2.transform);
            mypistol.TopPistol.transform.localPosition = Vector3.zero;
        }
        else
        {
            mypistol.TopPistol.transform.SetParent(Weapon2.transform);
            mypistol.TopPistol.transform.localPosition = Vector3.zero;
        }
        if (WeaponT == false)
        {
            myLaser.TopLaser.transform.SetParent(UnpackWeapon3.transform);
            myLaser.TopLaser.transform.localPosition = Vector3.zero;
        }
        else
        {
            myLaser.TopLaser.transform.SetParent(Weapon3.transform);
            myLaser.TopLaser.transform.localPosition = Vector3.zero;
        }
        if (WeaponFo == false)
        {
            myaxe.TopAxe.transform.SetParent(UnpackWeapon4.transform);
            myaxe.TopAxe.transform.localPosition = Vector3.zero;
        }
        else
        {
            myaxe.TopAxe.transform.SetParent(Weapon4.transform);
            myaxe.TopAxe.transform.localPosition = Vector3.zero;
        }
    }
    }
