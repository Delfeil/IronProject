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
}
