using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform CubeTransform;
    public Transform PivotTransform;
    public Transform MuzzleTransform;
    public Transform CameraTransform;

    public float BulletSpeed = 700.0f;
    public float ShootTime = 0.0f;
    public float ShootDelay = 0.1f;

    void Start()
    {
    }


    void Update()
    {
        CameraTransform = Abud_Pistol.Camera.transform;
    }

    public void ShootBullet()
    {
        Vector3 TargetPoint = CameraTransform.position + CameraTransform.forward * 100.0f;
        RaycastHit HitResult;
        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out HitResult, 100.0f))
        {
            TargetPoint = HitResult.point;
            

        }
        if (Input.GetAxis("Fire1") == 1.0f && Time.time >= ShootTime)
        {
            ShootTime = Time.time + ShootDelay;

            GameObject newBullet = Instantiate(Bullet, MuzzleTransform.position, Quaternion.LookRotation(TargetPoint - CubeTransform.position));
            Destroy(newBullet, 10.0f);

            Rigidbody newBulletRB = newBullet.GetComponent<Rigidbody>();
            newBulletRB.AddForce(newBullet.transform.forward * BulletSpeed, ForceMode.Impulse);


        }
    }

}
