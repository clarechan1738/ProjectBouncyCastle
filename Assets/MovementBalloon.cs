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
    public float Horizontal; //Input.GetAxisRaw("Horizontal") * (Time.deltaTime);
    public float Vertical; //(Input.GetAxisRaw("Vertical")) * (Time.deltaTime);
    public int Jumps = 2;
    public float JumpHeight = 40f;
    public bool IsGrounded = true;
    Rigidbody rigidbody;
    MeshRenderer Capsule;
    float _target = 3;
    float _current;
    float _speed = 5000f;
    public AudioSource AudioJump;
    public AudioSource AudioJump2;
    void Start()
    {
        Jumps = 2;
        rigidbody = GetComponent<Rigidbody>();
        Capsule = FindAnyObjectByType<MeshRenderer>();
    }
    void Update()
    {


        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        //needs to be changed to work with physics body

        //_target = _target == 0 ? 0 : _target;

        //_current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);

        if ((Convert.ToUInt64(Input.GetKeyDown(KeyCode.Z)) == 1))
        {
            rigidbody.AddForce(transform.up * 10000);
            print("You dashed");
        }

        if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.Space)) == 1)
        {
            IsGrounded = false;
            print("Jump button pressed");
            if (IsGrounded == false && Jumps != 0)
            {
                print("Executing Jump");
                rigidbody.AddForce(transform.forward * 5001);
                Jumps--;
                if (Jumps == 2) 
                    {
                    AudioJump.Play();
                }
                if (Jumps == 1)
                    {
                    AudioJump2.Play();
                }

            }
        }
    }
    private void FixedUpdate()
    {
       // transform.Translate(new Vector3(-Horizontal * SPEED, Vertical * SPEED, 0));
        rigidbody.velocity = new Vector3(Horizontal * SPEED, 0, Vertical * SPEED);
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