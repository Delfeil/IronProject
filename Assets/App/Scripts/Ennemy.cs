using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public GameObject StartingGameObject;

    public GameObject currentGameObject;

    private bool canMove = false;

    public float moveSpeed;

    private Vector3 offset = new Vector3(-1,0,0);

    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = StartingGameObject;
        transform.position = currentGameObject.transform.position + offset;
        Manager.Instance.Play += playButtonFunction;
        Manager.Instance.Stop += stopButtonFunction;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //Aller au currentObjectPosition
            Vector3 deplacement = currentGameObject.transform.position - transform.position;
            transform.position += deplacement.normalized * moveSpeed;
        }
    }

    void stopButtonFunction()
    {
        canMove = false;
        transform.position = StartingGameObject.transform.position + offset;
        currentGameObject = StartingGameObject;
        Debug.Log("Stop Function");
    }

    void playButtonFunction()
    {
        canMove = true;
        Debug.Log("Play Function");
    }
}
