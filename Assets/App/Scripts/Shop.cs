using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Shop : MonoBehaviour
{

    //Instance de lui meme 
    public static Shop Instance;

    //Placement d'objet via les UI 
    public GameObject TestObject;
    private bool clicked = false;
    private GameObject currentplacableObject;
    private GameObject placableObject;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject topArrow;
    public GameObject downArrow;
    Vector3 posPlacable;
    public LayerMask layyermask;

    //Lancement de signaux pour les ennemis
    public Action Play { get; set; }
    public Action Stop { get; set; }

    private void Awake() //Make this a singleton
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Starting()
    {
        Play?.Invoke();
        Debug.Log("StartSignal Launch");
    }
    public void Stopping()
    {
        Stop?.Invoke();
        Debug.Log("StopSignal Launch");
    }


    public void PurchaseLeftArrow()
    {
         placableObject = leftArrow;
         clicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (currentplacableObject != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hitInfos;
                if (Physics.Raycast(ray, out hitInfos, 3000, layyermask))
                {
                    if (hitInfos.collider.tag == "Socle")
                    {
                        Socles socle = hitInfos.collider.gameObject.GetComponent<Socles>();
                        if (socle.isTaken == false)
                        {
                            PlacementFinal();
                            clicked = false;
                            currentplacableObject = null;
                            placableObject = null;
                        }
                    }
                    else
                    {
                        clicked = false;
                        currentplacableObject = null;
                        placableObject = null;
                    }
                }      
            }
        }

        if (clicked)
        {
            Placement();
        }

    }

    public void Placement()
    {
        if (placableObject != null)
        {
            if (currentplacableObject != null)
            {
                Destroy(currentplacableObject);
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfos;
            if (Physics.Raycast(ray, out hitInfos, 3000, layyermask))
            {
                if (hitInfos.collider.tag == "Socle")
                {
                    Socles socle = hitInfos.collider.gameObject.GetComponent<Socles>();
                    if(socle.isTaken == false)
                    {
                        posPlacable = hitInfos.collider.transform.position + new Vector3(0, 0, -4);
                        currentplacableObject = Instantiate(placableObject, posPlacable, Quaternion.identity);
                    }
                }

                else
                {
                    posPlacable = hitInfos.point;
                    currentplacableObject = Instantiate(placableObject, posPlacable + new Vector3(0, 2, 0), Quaternion.identity);
                }
            }
        }
    }


    public void PlacementFinal()
    {
        if (placableObject != null && currentplacableObject != null)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfos;
            if (Physics.Raycast(ray, out hitInfos, 3000, layyermask))
            {
                if (hitInfos.collider.tag == "Socle")
                {
                    Socles socle = hitInfos.collider.gameObject.GetComponent<Socles>();
                    if (socle.isTaken == false)
                    {
                        posPlacable = hitInfos.collider.transform.position + new Vector3(0, 0, -4);
                        currentplacableObject = Instantiate(placableObject, posPlacable, Quaternion.identity);
                        socle.isTaken = true;
                    }
                }
            }
        }
        Destroy(currentplacableObject);
        placableObject = null;
    }
 
}
