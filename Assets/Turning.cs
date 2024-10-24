using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    public float Horizontal = Input.GetAxis("Horizontal") * (Time.deltaTime);
    public float Vertical = (Input.GetAxis("Vertical")) * (Time.deltaTime);
    const float SPEED = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = new Vector3(Horizontal * SPEED, 0, Vertical * SPEED);
    }
}
