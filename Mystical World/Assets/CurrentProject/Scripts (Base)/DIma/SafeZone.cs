using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SafeZone : MonoBehaviour
{

    public bool IsSafeZoneInOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IsSafeZoneInOut = true;
        NormalSafeZone(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        IsSafeZoneInOut = false;
        NormalSafeZone(other.gameObject);
    }

    public void NormalSafeZone(GameObject SafeZonenableObject)
    {
        ISafeZonenable ISafeZonenableObject = SafeZonenableObject.GetComponent<ISafeZonenable>();
        if (ISafeZonenableObject != null)
        {
            ISafeZonenableObject.IsSafeZone(IsSafeZoneInOut);
        }
    }
}
