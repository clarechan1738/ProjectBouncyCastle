using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{
    short dialogue = 1;
    [SerializeField]
    private GameObject dialogue1;
    [SerializeField]
    private GameObject dialogue2; 
    [SerializeField]
    private GameObject dialogue3;
    [SerializeField]
    private GameObject dialogue4;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dialogue"))
        {


            if (dialogue == 1)
            {
                dialogue++;
                dialogue1.SetActive(true);
                Destroy(other.gameObject);
            }
            else if (dialogue == 2)
            {
                dialogue++;
                dialogue2.SetActive(true);
                Destroy(other.gameObject);
            }
            else if (dialogue == 3)
            {
                dialogue++;
                dialogue3.SetActive(true);
                Destroy(other.gameObject);
            }
            else
            {
                dialogue++;
                dialogue4.SetActive(true);
                Destroy(other.gameObject);
            }
        }
        // GameManagerDependencyInfo.FinishedGame(); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
