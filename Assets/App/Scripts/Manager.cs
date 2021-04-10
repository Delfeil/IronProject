using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{

    //Instance de lui meme 
    public static Manager Instance;

    //Lancement de signaux pour les ennemis
    public Action Play { get; set; }
    public Action Stop { get; set; }
    public Action previewAction { get; set; }

    //Variables position des murs de la map 
    private float tailleMatrix = 8;
    public GameObject walls;
    public GameObject damierCentral;
    public Transform transformParents;
    [SerializeField]Vector3 posFirstBrick = new Vector3(0,0,0);
    Vector3 currentPos;
    private Collider wallCollider;
    public float sizeWallCollider;

    private float marge = 0.01f;

    public bool preview = false;

    [Header("UI")]
    [SerializeField] GameObject uiVictory;
    [SerializeField] float victoryDisplayTime;
    private Coroutine victory;
    private Socles[] socleArray;

    public GameObject uiPlayButton;
    [SerializeField] GameObject uiPreviewButton;
    ActionController[] arrayAllActions;


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
        uiPlayButton.SetActive(false);
        socleArray = FindObjectsOfType<Socles>();
        arrayAllActions = FindObjectsOfType<ActionController>();
    }

    public void Preview()
    {
        uiPlayButton.SetActive(false);
        uiPreviewButton.SetActive(false);
        desactiveAllActions();
        preview = true;
        Play?.Invoke();
        Debug.Log("Preview Launch");
    }

    public void desactiveAllActions()
    {
        foreach (var ActionController in arrayAllActions)
        {
            ActionController.gameObject.SetActive(false);
        }
    }
    public void activeAllActions()
    {
        foreach (var ActionController in arrayAllActions)
        {
            ActionController.gameObject.SetActive(true);
        }
    }
    public void enableDragDropOnAllActions()
    {
        foreach (var ActionController in arrayAllActions)
        {
            DragObject scriptdrag = ActionController.gameObject.GetComponent<DragObject>();
            scriptdrag.enabled = false;
        }
    }
    public void ableDragDropOnAllActions()
    {
        foreach (var ActionController in arrayAllActions)
        {
            DragObject scriptdrag = ActionController.gameObject.GetComponent<DragObject>();
            scriptdrag.enabled = true;
        }
    }

    public void Starting()
    {
        if (soclesAllActives())
        {
            uiPreviewButton.SetActive(false);
            uiPlayButton.SetActive(false);
            enableDragDropOnAllActions();
            preview = false;
            Play?.Invoke();
            Debug.Log("StartSignal Launch");
        }
        else
        {
            Debug.Log("Les socles ne sont pas tous actifs ! ");
        }
    }
    public void Stopping()
    {
        uiPreviewButton.SetActive(true);
        PlayerController.Instance.replacePlayerInitialPos();
        ableDragDropOnAllActions();
        activeAllActions();

        if (soclesAllActives())
        {
            uiPlayButton.SetActive(true);
        }

        Stop?.Invoke();
        Debug.Log("StopSignal Launch");
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
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

        GameObject damier = Instantiate(damierCentral, transformParents);
        damier.transform.localPosition = currentPos - new Vector3(-(sizeWallCollider * 3 + sizeWallCollider / 2), sizeWallCollider * 3 + sizeWallCollider/2, -0.1f);
    }

    internal void Victory()
    {
        Debug.Log("VICTORY");
        victory = StartCoroutine(displayVictoryScreen());
    }

    public IEnumerator displayVictoryScreen()
    {
        uiVictory.SetActive(true);
        yield return new WaitForSeconds(victoryDisplayTime);
        SceneManager.LoadScene(0);
    }

    internal void Gameover()
    {
        Debug.Log("Game Over");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool soclesAllActives()
    {
        int nbLenght = socleArray.Length;
        int count = 0;

        foreach (var socles in socleArray)
        {
            if (socles.isActive)
            {
                count += 1;
            }
        }     
        if(count == nbLenght)
        {
            return true;
        }
        return false;
        count = 0;
    }
}
