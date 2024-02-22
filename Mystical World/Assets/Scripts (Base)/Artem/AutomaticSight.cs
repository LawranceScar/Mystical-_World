using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticSight : MonoBehaviour
{

    [SerializeField] private GameObject Cube;

    [SerializeField] private float Radius = 2.0f;

    [SerializeField] private Movement Move;

    private Vector3 LastPos;
    private float Speed;
    [SerializeField] private float ComingToEnemySpeed = 10f;

    

    private void Start()
    {
        LastPos = gameObject.transform.position;
    }

    void Update()
    {
        Speed = (gameObject.transform.position - LastPos).magnitude / Time.deltaTime;
        FindingEnemyUsingOverlapsphere();

        Debug.Log(Speed + " = Speed");

        LastPos = gameObject.transform.position;
    }

    float FindAngle(GameObject Enemy)
    {
        return Vector3.Angle(gameObject.transform.forward, Enemy.gameObject.transform.position - gameObject.transform.position);
    }

    int FindNumberOfMinAngle(List<float> Angles)
    {
        int MinAngle = 0;
        for (int i = 0; i < Angles.Count; i++)
        {
            if(Angles[i] < Angles[MinAngle])
            {
                MinAngle = i;
            }
        }
        return MinAngle;
    }


    void FindingEnemyUsingOverlapsphere()
    {
        if (Speed != 0.0f)
        {
            List<Collider> Enemies = new List<Collider>();
            List<float> Angles = new List<float>();
            Dictionary<Collider, float> EnemiesAndAngles = new Dictionary<Collider, float>();

            Collider[] ObjectsInOverlapSphere = Physics.OverlapSphere(gameObject.transform.position, Radius);
            

            for (int i = 0; i < ObjectsInOverlapSphere.Length; i++)
            {
                if (ObjectsInOverlapSphere[i].CompareTag("Enemy"))
                {

                    Enemies.Add(ObjectsInOverlapSphere[i]);
                }
            }

             

            for (int i = 0; i < Enemies.Count; i++)
            {
                Angles.Add(FindAngle(Enemies[i].gameObject));
            }

            if (Enemies.Count > 0)
            {
                Cube.transform.position = Enemies[FindNumberOfMinAngle(Angles)].gameObject.transform.position + new Vector3(0.0f, 2.0f, 0.0f);
                Move.MoveTowards(Enemies[FindNumberOfMinAngle(Angles)].gameObject.transform.position + new Vector3(0.0f, 2.0f, 0.0f),ComingToEnemySpeed);
            }
        }
    }
}
