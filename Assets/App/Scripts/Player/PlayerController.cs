using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("params")]
    [SerializeField] float moveFactor;
    [SerializeField] protected LayerMask wallLayer;
    [SerializeField] protected float raycastWallDist;

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
        if (CanMove(dir))
        {
            transform.position += dir * moveFactor;
        }
    }

    protected bool CanMove(Vector3 dir)
    {
        RaycastHit hit;
        return !Physics.Raycast(transform.position, dir, out hit, raycastWallDist, wallLayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            // TODO: Implement Game Over
            Debug.Log("Game Over");
        }
        else if (other.gameObject.tag == "victory")
        {
            // TODO: Implement Victory
            Debug.Log("Vicrtory");
        }
    }
}
