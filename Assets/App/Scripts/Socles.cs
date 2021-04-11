using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socles : MonoBehaviour
{
    public bool isActive = false;

    private DragObject dragobj = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Action" && !isActive)
        {
            isActive = true;
            dragobj =  other.GetComponent<DragObject>();
            dragobj.isOnSocle = true;
            dragobj.posSocle = transform.position;
            Debug.Log("ENTRE DANS LE SOCLE");
            

            if (Manager.Instance.soclesAllActives())
            {
                Manager.Instance.uiPlayButton.SetActive(true);
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Action")
        {
            if (other.gameObject == dragobj.gameObject)
            {
                dragobj.isOnSocle = false;
                dragobj.posSocle = dragobj.startpos;
                Debug.Log("QUITTE LE SOCLE");
                Manager.Instance.uiPlayButton.SetActive(false);
                isActive = false;
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Action")
        {
            DragObject dragobj = other.GetComponent<DragObject>();
            *//*if (!dragobj.isOnSocle)
                return;*//*
            dragobj.isOnSocle = false;
            dragobj.posSocle = dragobj.startpos;
            Debug.Log("QUITTE LE SOCLE");
            Manager.Instance.uiPlayButton.SetActive(false);
            isActive = false;
        }
    }*/
}
