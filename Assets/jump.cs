using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public AudioSource AudioJump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.Space)) == 1)
        {
            AudioJump.Play();
        }
    }
}
