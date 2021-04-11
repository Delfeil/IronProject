using System;
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

    Animator animator;

    AudioSource audioSource;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetTrigger("IDLE");
    }

    void Start()
    {
        currentGameObject = StartingGameObject;
        transform.position = currentGameObject.transform.position;
        Manager.Instance.Play += playButtonFunction;
        Manager.Instance.Stop += stopButtonFunction;
    }

    private void OnDisable()
    {
        Manager.Instance.Play -= playButtonFunction;
        Manager.Instance.Stop -= stopButtonFunction;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //Aller au currentObjectPosition
            Vector3 deplacement = currentGameObject.transform.position - transform.position;
            transform.position += deplacement.normalized * moveSpeed *Time.deltaTime;
        }
    }

    public void SetAnimation(MovmentType moveType)
    {
        animator.SetTrigger(Enum.GetName(typeof(MovmentType), moveType));
    }

    void stopButtonFunction()
    {
        canMove = false;
        transform.position = StartingGameObject.transform.position;
        currentGameObject = StartingGameObject;
        animator.SetTrigger("IDLE");
        audioSource.Stop();
        Debug.Log("Stop Function");
    }

    void playButtonFunction()
    {
        canMove = true;
        animator.SetTrigger("MOVE");
        audioSource.Play();
        Debug.Log("Play Function");
    }
}
