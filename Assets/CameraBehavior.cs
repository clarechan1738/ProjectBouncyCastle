using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject Part2;
    [SerializeField]
    GameObject MainCamera;
    [SerializeField]
    GameObject Part2Camera;
    [SerializeField]
    Camera Part3Camera;
    [SerializeField]
    Camera Part4Camera;
    [SerializeField]
    GameObject Part3Camera2;
    [SerializeField]
    GameObject Part4Camera2;
    public bool cameraFlipped = false;
    bool Cameramode = false;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Cameramode == false)
            {
            if (other.CompareTag("Part2"))
            {
                cameraFlipped = true;
                Destroy(MainCamera);
            }
            if (cameraFlipped == true)
            {
                Part2Camera.SetActive(true);
            }
        }
        if (other.CompareTag("CamSwitch"))
        {
            Part3Camera2.SetActive(true);
            Part4Camera2.SetActive(true);
            Cameramode = true;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Cameramode == true) 
        {
            Destroy(MainCamera);
            Destroy(Part2Camera);
            if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.Alpha1)) == 1)
            {
                Part3Camera2.SetActive(false);
                Part4Camera2.SetActive(true);
            }
            if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.Alpha2)) == 1)
            {
                Part3Camera2.SetActive(true);
                Part4Camera2.SetActive(false);
            }
        }
    }
}
