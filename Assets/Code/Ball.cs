using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed; 
    public Vector2 direction;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;    
        body.velocity = direction.normalized * speed;
    }

    public void StopBall()
    {
        body.velocity = Vector2.zero;
    }
}
