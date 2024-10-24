using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{
    short dialogue = 1;
    [SerializeField]
    private GameObject dialogue1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dialogue")) 
        {
            switch (dialogue)
            {
                case 1:
                    dialogue = 2;
                    dialogue1.SetActive(true);
                    break;

                case 2:
                    dialogue = 3;
                    break;

                case 3:
                    dialogue = 4;
                    break;

            }


        };

        // GameManagerDependencyInfo.FinishedGame(); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
