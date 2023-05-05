using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] List<Transform> Teleports = new List<Transform>();

    static public List<bool> IsActiv = new List<bool>();
    private bool CanUse = false;

    static private int Index = 0;

    [SerializeField] private Transform Player;

    void Start()
    {
        Index = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!CanUse)
            {
                CanUse = true;
                Debug.Log("Can Use");
            }
            else if (CanUse)
            {
                CanUse = false;
                Debug.Log("Cant Use");
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < Teleports.Count - 1; i++)
            {
                if(this.transform == Teleports[i])
                {
                    IsActiv[i] = true;
                }
            }
        }
    }
     private void ChangePosition()
     {

        if (Input.GetAxis("Fire2") > 0)
        {
            if (CanUse && IsActiv[Index])
            {
                Player.position = Teleports[Index].position;
            }
        }
     }

    private void NextIndex()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Index = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Index = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Index = 3;
        }
    }
}
