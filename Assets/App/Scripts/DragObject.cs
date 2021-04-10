﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    public Vector3 startpos;

    public bool isOnSocle = false;

    public Vector3 posSocle; 

    private void Start()
    {
        startpos = transform.position;
    }

    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()

    {
        if (this.enabled)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }

    private void OnMouseUp()
    {
        if (isOnSocle)
        {
            transform.position = new Vector3(posSocle.x, posSocle.y, -0.001f);
        }
        else { transform.position = startpos; }
    }
}
