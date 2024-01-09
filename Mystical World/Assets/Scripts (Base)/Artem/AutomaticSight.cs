using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticSight : MonoBehaviour
{

    [SerializeField] private GameObject Cube;

    [SerializeField] private float Radius = 2.0f;

    [SerializeField] private Movement Move;

    void Update()
    {
        FindingEnemyUsingOverlapsphere();
    }

    float FindAngle(List <Collider> Enemies, int i)
    {
        return Vector3.Angle(gameObject.transform.forward, Enemies[i].gameObject.transform.position - gameObject.transform.position);
    }

    int FindMinAngle(List<float> Angles)
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
        if (Move.Controller.velocity.magnitude != 0.0f)
        {
            List<Collider> Enemies = new List<Collider>();
            List<float> Angles = new List<float>();

            Collider[] ObjectsInOverlapSphere = Physics.OverlapSphere(gameObject.transform.position, Radius);


            for (int i = 0; i < ObjectsInOverlapSphere.Length; i++)
            {
                if (ObjectsInOverlapSphere[i].CompareTag("Enemy"))
                {
                    Enemies.Add(ObjectsInOverlapSphere[i]);
                }
                else
                {
                    ObjectsInOverlapSphere[i] = null;
                }
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                Angles.Add(FindAngle(Enemies, i));
            }

            if (Enemies.Count > 0)
            {
                Cube.transform.position = Enemies[FindMinAngle(Angles)].gameObject.transform.position + new Vector3(0.0f, 2.0f, 0.0f);
            }
        }
    }
}
