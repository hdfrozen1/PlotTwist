using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class OpenDoorButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;
    public HandleOpenDoor handleOpenDoor;
    public event Action teleportPlayer;
    public Sprite openDoor;
    public Sprite closeDoor;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;
        handleOpenDoor = GameObject.FindObjectOfType<HandleOpenDoor>();
    }
    void Start()
    {
        sprite.sprite = closeDoor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        handleOpenDoor.BeginOpenDoor();
        teleportPlayer?.Invoke();
        sprite.sprite = openDoor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        sprite.sprite = closeDoor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            sprite.sprite = openDoor;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            sprite.sprite = closeDoor;
        }
    }
}
