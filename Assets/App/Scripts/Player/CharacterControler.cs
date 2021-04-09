using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("params")]
    [SerializeField] float moveFactor;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(MovmentType moveType)
    {
        Vector3 dir;
        switch (moveType)
        {
            case MovmentType.UP:
                dir = Vector3.up;
                break;
            case MovmentType.DOWN:
                dir = Vector3.down;
                break;
            case MovmentType.LEFT:
                dir = Vector3.left;
                break;
            case MovmentType.RIGHT:
                dir = Vector3.right;
                break;
            default:
                return;
                break;
        }
        transform.position += dir * moveFactor;
    }
}
