using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ShootLaser : MonoBehaviour
{
    public Transform Lazer;
    public static LineRenderer mylinerenderer;
    public GameObject camera;
    public float damage = 10;
    public float range = 200.0f;
    public bool huh = true;
    void Start()
    {
        mylinerenderer = GetComponent<LineRenderer>();

        mylinerenderer.enabled = false;
    }

   public void ShootLazer()
    {
        Lazer.transform.forward = camera.transform.forward;
        Vector3[] Line = new Vector3[2];
        Line[0] = Lazer.transform.position;
        Line[1] = Lazer.transform.position + Lazer.transform.forward * 100f;

        RaycastHit hit;
        if (Physics.Raycast(Lazer.transform.position, Lazer.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.gameObject != null)
            {
                Line[1] = hit.point;
            }
            else
            {
                Line[1] = Lazer.transform.position + Lazer.transform.forward * 100f;
            }
            if (AbudLaser.workLaser == true)
            {
                if (hit.transform.gameObject != null && hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("AbobA Andr");
                    NormalReceiveDamage(hit.transform.gameObject);
                }
            }
        }
        mylinerenderer.SetPositions(Line);

    }


    public void NormalReceiveDamage(GameObject DamagableObject)
    {
        IDamagable IDamagableObject = DamagableObject.GetComponent<IDamagable>();
        if (IDamagableObject != null)
        {
            IDamagableObject.TakerDamage(damage); //ReceiveRealDamage
        }
    }
}
      

