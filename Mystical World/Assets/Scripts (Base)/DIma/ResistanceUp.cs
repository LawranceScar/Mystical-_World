using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class ResistanceUp : MonoBehaviour
{

    public float Resistance = 0.03f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            NormalResistanceZone(other.gameObject);
        }
    }

    public void NormalResistanceZone(GameObject ResistanceZoneObject)
    {
        IResistancable IResistanceZoneObject = ResistanceZoneObject.GetComponent<IResistancable>();
        if (IResistanceZoneObject != null)
        {
            IResistanceZoneObject.UpResistance(Resistance);
        }
    }
}
