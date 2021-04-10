using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Manager : MonoBehaviour
{

    //Instance de lui meme 
    public static Manager Instance;

    //Lancement de signaux pour les ennemis
    public Action Play { get; set; }
    public Action Stop { get; set; }


    //Variables position des murs de la map 
    private float tailleMatrix = 8;
    public GameObject walls;
    public Transform transformParents;
    [SerializeField]Vector3 posFirstBrick = new Vector3(0,0,0);
    Vector3 currentPos;
    private Collider wallCollider;
    private float sizeWallCollider;

    private float marge = 0.01f;


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

    private void Start()
    {
        wallCollider = walls.GetComponent<BoxCollider>();
        sizeWallCollider = wallCollider.bounds.size.x;
        //posFirstBrick += new Vector3(wallCollider.bounds.size.x / 2, wallCollider.bounds.size.x / 2, 0);
        currentPos = posFirstBrick;
        InstantiateLevel();
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

    void InstantiateLevel()
    {
        for (int i = 0; i < tailleMatrix; i++)
        {
            GameObject wall =  Instantiate(walls, transformParents);
            wall.transform.localPosition = currentPos;
            currentPos += new Vector3(sizeWallCollider, 0 , 0);
        }
        currentPos -= new Vector3(sizeWallCollider, 0, 0);
        currentPos -= new Vector3(0, sizeWallCollider, 0);
        for (int i = 0; i < tailleMatrix-1; i++)
        {
            GameObject wall = Instantiate(walls, transformParents);
            wall.transform.localPosition = currentPos;
            currentPos -= new Vector3(0, sizeWallCollider, 0);
        }
        currentPos += new Vector3(0, sizeWallCollider, 0);
        currentPos -= new Vector3(sizeWallCollider, 0, 0);
        for (int i = 0; i < tailleMatrix - 1; i++)
        {
            GameObject wall = Instantiate(walls, transformParents);
            wall.transform.localPosition = currentPos;
            currentPos -= new Vector3(sizeWallCollider, 0, 0);
        }
        currentPos += new Vector3(sizeWallCollider, 0, 0);
        currentPos += new Vector3(0, sizeWallCollider, 0);
        for (int i = 0; i < tailleMatrix - 2; i++)
        {
            GameObject wall = Instantiate(walls, transformParents);
            wall.transform.localPosition = currentPos;
            currentPos += new Vector3(0, sizeWallCollider, 0);
        }

    }

    internal void Victory()
    {
        Debug.Log("Vicrtory");
    }

    internal void Gameover()
    {
        Debug.Log("Game Over");
    }
}
