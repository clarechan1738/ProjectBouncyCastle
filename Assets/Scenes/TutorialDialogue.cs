using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{
    short dial = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dialogue")) 
        {
            switch (dial)
            {
                case 1:
                    dial = 2;
                    break;

                case 2:
                    dial = 3;
                    break;

                case 3:
                    dial = 4;
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
