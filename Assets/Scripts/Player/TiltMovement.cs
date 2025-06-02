using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    Vector2 tilt;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = Vector2.zero;
    }
    void Update()
    {
        tilt = Input.acceleration;
    }
    void FixedUpdate()
    {
        
        Vector2 move = tilt * speed;
        rb.velocity = move;
    }
}
