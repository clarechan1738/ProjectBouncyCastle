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
    public bool IsGrounded = true;
    Rigidbody rigidbody;
    MeshRenderer Capsule;

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

        Vector3 vector3 = this.transform.forward;
        if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.Space)) == 1)
        {
            IsGrounded = false;
            print("Jump button pressed");
        }
        if ((Convert.ToUInt64(Input.GetKeyDown(KeyCode.Space)) == 1) && IsGrounded == false && Jumps != 0)
        {
            print("Executing Jump");
            transform.position = new Vector3(transform.position.x, (transform.position.y + 5), transform.position.z);
            Jumps--;
        }
        if ((Convert.ToUInt64(Input.GetKeyDown(KeyCode.LeftShift)) == 1)) ;
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