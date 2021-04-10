using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [Header("params")]
    /*[SerializeField] float moveFactor;*/
    private float moveFactor;
    [SerializeField] protected float moveDuration;
    [SerializeField] protected AnimationCurve moveAnim;
    [SerializeField] protected LayerMask wallLayer;
    [SerializeField] protected float raycastWallDist;

    private Animator animator;
    private Coroutine moving;

    private Collider ownCOllider;
    private float sizeCollider;

    private void Awake() //Make this a singleton
    {
        if (Instance == null)
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
        ownCOllider = GetComponent<BoxCollider>();
        sizeCollider = ownCOllider.bounds.size.x;
        moveFactor = sizeCollider;
    }

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
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
        if (CanMove(dir))
        {
            MoveToPosition(transform.position + (dir * moveFactor), moveType);
        }
    }

    protected bool CanMove(Vector3 dir)
    {
        RaycastHit hit;
        return !Physics.Raycast(transform.position, dir, out hit, raycastWallDist, wallLayer);
    }
    
    private void MoveToPosition(Vector3 position, MovmentType moveType)
    {
        if (position != null)
        {
            moving = StartCoroutine(MoveCharacter(position, moveType));
        }
    }

    private IEnumerator MoveCharacter(Vector3 position, MovmentType moveType)
    {
        //animator.SetTrigger(Enum.GetName(typeof(MovmentType), moveType));
        transform.DOMove(position, moveDuration).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(moveDuration);
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
