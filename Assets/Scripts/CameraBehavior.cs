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
    public bool cameraFlipped = false;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
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
    // Update is called once per frame
    void Update()
    {
       
    }
}
