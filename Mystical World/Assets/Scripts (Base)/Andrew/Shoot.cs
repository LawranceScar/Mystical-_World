using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform CubeTransform;
    public Transform MuzzleTransform;
    public Transform CameraTransform;
    public float BulletSpeed = 700.0f;
    public float ShootTime = 0.0f;
    public float ShootDelay = 0.1f;
    public float damage = 30;


    void Update()
    {
        
        CameraTransform = Abud_Pistol.ShootCamera.transform;  
        
    }

    public void ShootBullet()
    {
        Vector3 TargetPoint = CameraTransform.position + CameraTransform.forward * 100.0f;
        RaycastHit HitResult;
        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out HitResult, 100.0f))
        {
            TargetPoint = HitResult.point;
        } 

        if (Time.time >= ShootTime)
        {
            ShootTime = Time.time + ShootDelay;

            GameObject newBullet = Instantiate(Bullet, MuzzleTransform.position, Quaternion.LookRotation(TargetPoint - CubeTransform.position));
            Destroy(newBullet, 10.0f);
            

            Rigidbody newBulletRB = newBullet.GetComponent<Rigidbody>();

            // -------------------------Зміна дамагу для нових клонів пуль----------------------------------

            BulletScript BulletOverrideDamage = newBullet.GetComponent<BulletScript>();

            BulletOverrideDamage.SetCurrentDamage(damage); // Задаємо саме значення з public змінної 

            // ----------------------------------------------------------

            newBulletRB.AddForce(newBullet.transform.forward * BulletSpeed, ForceMode.Impulse);


        }


    }

}
