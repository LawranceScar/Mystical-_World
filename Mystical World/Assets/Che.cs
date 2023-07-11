using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Che : MonoBehaviour
{
    bool IsOpen;
     public Transform spawnpoint;
    [SerializeField]public MeshRenderer mymaterial;
    [SerializeField]public Material Onepmat;
    [SerializeField]List<GameObject> items = new List<GameObject>();
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            SpawnWeapon(Random.Range(0, 4));
        }
    }
    public void SpawnWeapon(int r)
    {
        if (!IsOpen)
        {
            GameObject weapon = Instantiate(items[r], spawnpoint.position, Quaternion.LookRotation(spawnpoint.transform.forward));
            mymaterial.material = Onepmat;
           
        }

            IsOpen = true;
    }
}
