using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;


public class MovementBalloon : MonoBehaviour
{
    const float SPEED = 10;
    public float Horizontal;
    public float Vertical;
    public int Jumps = 2;
    public float JumpHeight = 40f;
    public bool IsGrounded = true;
    Rigidbody rigidbody;
    MeshRenderer Capsule;
    float _target = 3;
    float _current;
    float _speed = 5000f;

    //Reference To Camera Script
    CameraBehavior cBehavior;


    void Start()
    {
        Jumps = 2;
        rigidbody = GetComponent<Rigidbody>();
        Capsule = FindAnyObjectByType<MeshRenderer>();
        cBehavior = FindAnyObjectByType<CameraBehavior>();

    }
    void Update()
    {


        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.Space)) == 1)
        {
            IsGrounded = false;
            print("Jump button pressed");
            if (IsGrounded == false && Jumps != 0)
            {
                print("Executing Jump");
                rigidbody.AddForce(transform.forward * 5001);
                Jumps--;

            }
        }
    }
    private void FixedUpdate()
    {
        if (cBehavior.cameraFlipped)
        {
            rigidbody.velocity = new Vector3(Horizontal * SPEED, 0, Vertical * SPEED);
        }
        else
        {
            rigidbody.velocity = new Vector3(-Vertical * SPEED, 0, Horizontal * SPEED);
        }
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Translate(Vector3.forward - Vector3.forward);
            Jumps = 2;
            IsGrounded = true;
        }

    }
}