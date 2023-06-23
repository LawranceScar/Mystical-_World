using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] List<Transform> Teleports = new List<Transform>();

    static private List<bool> IsActiv = new List<bool>();

    static private int I;
    private int LastI;

    [SerializeField] private Transform Player;

    void Start()
    {
        IsActiv.Add(false);
        LastI = -1;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && LastI > -1)
        {
            I = LastI + 1;
            if(I > Teleports.Count - 1)
            {
                I = 0;
            }

            while(true)
            {
                Debug.Log("Index =" + I);
                Debug.Log("LastIndex =" + LastI);

                if (IsActiv[I])
                {
                    Player.position = Teleports[I].position;
                    LastI = I;
                    break; 
                }
                else 
                {
                    I++;
                    if (I >= Teleports.Count)
                    {
                        I = 0;
                    }
                }
            }
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < Teleports.Count; i++)
            {
                if(this.transform == Teleports[i])
                {
                    IsActiv[i] = true;
                    LastI = i;
                }
            }
        }
    }
}
