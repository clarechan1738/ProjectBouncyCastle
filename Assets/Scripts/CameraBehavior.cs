using System;
using System.Collections;
using System.Collections.Generic;
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
    GameObject Part3Camera;
    [SerializeField]
    GameObject Part4Camera;
    [SerializeField]
    Camera Part5Camera;
    [SerializeField]
    Camera Part6Camera;
    [SerializeField]
    GameObject Part5Camera2;
    [SerializeField]
    GameObject Part6Camera2;

    public bool cameraFlipped = false;
    bool Cameramode = false;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        print("TriggerEntered");
        if (Cameramode == false)
        {
            if (other.CompareTag("Part2"))
            {
                cameraFlipped = true;
                Part2Camera.SetActive(true);
                Destroy(MainCamera);
                print("CameraShouldSwitch");
            }
            if (other.CompareTag("Part3"))
            {
                cameraFlipped = true;
                Part3Camera.SetActive(true);
                Destroy(Part2Camera);
                print("CameraShouldSwitch");
            }
            if (other.CompareTag("Part4"))
            {
                cameraFlipped = true;
                Part4Camera.SetActive(true);
                Destroy(Part2Camera);
                print("CameraShouldSwitch");
            }
            if (other.CompareTag("CamSwitch"))
            {
                Cameramode = true;
                Part5Camera2.SetActive(true);
                Part6Camera2.SetActive(true);

            }
        }
    }
        // Update is called once per frame
        void Update()
        {
            if (Cameramode == true)
            {
                print("CameraModeEnabled");
                Destroy(MainCamera);
                Destroy(Part2Camera);
                Destroy(Part3Camera);

                if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.G)) == 1)
                {
                    Part5Camera2.SetActive(false);
                    Part6Camera2.SetActive(true);
                    print("1IsPressed");
                }
                if (Convert.ToUInt64(Input.GetKeyDown(KeyCode.T)) == 1)
                {
                    Part5Camera2.SetActive(true);
                    Part6Camera2.SetActive(false);
                    print("2IsPressed");
                }
            }
        }
}
