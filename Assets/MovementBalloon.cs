using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class MovementBalloon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        var SPEED = 30;
        var Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        var Vertical = (Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Translate(new Vector3(Horizontal * SPEED, 0, Vertical * SPEED));
        if (Convert.ToUInt64(Input.GetButton("Jump")) == 1 && transform.position.y <= 30)
        {
            transform.position = new Vector3(transform.position.x, 30, transform.position.z);
        }
    }
}
