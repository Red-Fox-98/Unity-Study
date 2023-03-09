using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rigidBody;
    private Animator animation;
    public SpriteRenderer sprite;
    public int w = 0;
    public int s = 0;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private States State
    {
        get { return (States)animation.GetInteger("state"); }
        set { animation.SetInteger("state", (int)value); }
    }

    void Update()
    {
        if (Input.GetButton("Vertical"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                RunUp();
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                RunDown();
            }
        }
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                RunLeft(); 
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                RunRight();
            }
        }
    }

    private void RunUp()
    {
        State = States.up;
        Vector3 vector = transform.up * 0.5f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + vector, speed * Time.deltaTime);
    }

    private void RunDown()
    {
        State = States.down;
        Vector3 vector = transform.up * (-0.5f);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + vector, speed * Time.deltaTime);
    }

    private void RunLeft()
    {
        State = States.left;
        Vector3 vector = transform.right * (-0.5f);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + vector, speed * Time.deltaTime);
    }

    private void RunRight()
    {
        State = States.right;
        Vector3 vector = transform.right * 0.5f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + vector, speed * Time.deltaTime);
    }

    public enum States
    {
        up,
        down,
        left,
        right,
    }
}
