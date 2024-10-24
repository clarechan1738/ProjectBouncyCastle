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

//please help
public class MovementBalloon : MonoBehaviour
{

    // Start is called before the first frame update
    const float SPEED = 10;
    public float Horizontal = Input.GetAxis("Horizontal") * (Time.deltaTime);
    public float Vertical = (Input.GetAxis("Vertical")) * (Time.deltaTime);
    public int Jumps = 2;
    public float JumpHeight = 40f;
    public bool IsGrounded = true;
    Rigidbody rigidbody;
    MeshRenderer Capsule;
    float _target = 3;
    float _current;
    float _speed = 0.5f;

    void Start()
    {
        Jumps = 2;
        rigidbody = FindAnyObjectByType<Rigidbody>();
        Capsule = FindAnyObjectByType<MeshRenderer>();
    }
    void Update()
    {


        Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vertical = (Input.GetAxis("Vertical") * Time.deltaTime);

        transform.Translate(new Vector3(Horizontal * SPEED, 0, Vertical * SPEED));

        _target = _target == 0 ? 0 : _target;

        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);

        if ((Convert.ToUInt64(Input.GetKeyDown(KeyCode.Z)) == 1))
        {
            transform.Translate(transform.forward * 5);
            print("You dashed");
        }

        if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.Space)) == 1)
        {
            IsGrounded = false;
            print("Jump button pressed");

            if (IsGrounded == false && Jumps != 0)
            {
                print("Executing Jump");
                rigidbody.AddForce(transform.up * JumpHeight);
                Jumps--;

                print(_current);
            }
        }
    }
       void OnCollisionEnter(Collision collision)
       {
            Jumps = 2;
            IsGrounded = true;

            if (collision.gameObject.CompareTag("Wall"))
            {
                transform.Translate(Vector3.forward - Vector3.forward);
            }
       }
}