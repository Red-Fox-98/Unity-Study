using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    public Vector3 motionState;
    public Vector3 oldMotionVector;
    public StateOfAnimations animationState;
    public float speed = 3f;

    private Rigidbody2D rigidBody;
    private new Animator animation;
    public SpriteRenderer sprite;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    private StateOfAnimations AnimationState
    {
        get { return (StateOfAnimations)animation.GetInteger("state"); }
        set { animation.SetInteger("state", (int)value); }
    }

    private void FixedUpdate()
    {
        CheckMoving();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            motionState = Vector3.up;
            animationState = StateOfAnimations.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            motionState = Vector3.down;
            animationState = StateOfAnimations.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            motionState = Vector3.left;
            animationState = StateOfAnimations.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            motionState = Vector3.right;
            animationState = StateOfAnimations.right;
        }
        Move(motionState, animationState);
        oldMotionVector = transform.position;
    }

    private void Move(Vector3 motionState, StateOfAnimations animationState)
    {
        AnimationState = animationState;
        Vector3 vector = motionState * 0.5f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + vector, speed * Time.deltaTime);
    }

    private void CheckMoving()
    {
        if (oldMotionVector == transform.position)
        {
            motionState = Vector3.zero;
            Move(motionState, animationState);
        }
    }

    public enum StateOfAnimations
    {
        up,
        down,
        left,
        right,
    }
}