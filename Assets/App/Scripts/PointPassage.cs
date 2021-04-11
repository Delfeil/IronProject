using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPassage : MonoBehaviour
{
    public GameObject nextPointPassage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemy")
        {

            Ennemy comp = other.GetComponent<Ennemy>();
            other.transform.position = transform.position;
            comp.currentGameObject = nextPointPassage;
        }
    }
}
