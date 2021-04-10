using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socles : MonoBehaviour
{
    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Action")
        {
            DragObject dragobj =  other.GetComponent<DragObject>();
            dragobj.isOnSocle = true;
            dragobj.posSocle = transform.position;
            Debug.Log("ENTRE DANS LE SOCLE");
            isActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Action")
        {
            DragObject dragobj = other.GetComponent<DragObject>();
            dragobj.isOnSocle = false;
            dragobj.posSocle = dragobj.startpos;
            Debug.Log("QUITTE LE SOCLE");
            isActive = false;
        }
    }
}
