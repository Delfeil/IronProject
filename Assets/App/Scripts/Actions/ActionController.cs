﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerController player;
    protected SpriteRenderer spriteRenderer;

    [Header("Properties")]
    [SerializeField] MovmentType movmentType;

    [Header("Sprites")]
    [SerializeField] protected Sprite upSprite;
    [SerializeField] protected Sprite downSprite;
    [SerializeField] protected Sprite leftSprite;
    [SerializeField] protected Sprite rightSprite;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetIcon(movmentType);
    }

    protected void SetIcon(MovmentType movmentType)
    {
        switch (movmentType)
        {
            case MovmentType.UP:
                spriteRenderer.sprite = upSprite;
                break;
            case MovmentType.DOWN:
                spriteRenderer.sprite = downSprite;
                break;
            case MovmentType.LEFT:
                spriteRenderer.sprite = leftSprite;
                break;
            case MovmentType.RIGHT:
                spriteRenderer.sprite = rightSprite;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            player.Move(this.movmentType);
        }
    }
}
