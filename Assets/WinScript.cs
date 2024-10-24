using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    //public bool damageCollider = false;
    //bool isRunning = false;
    //public bool isFinished = false;   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided With" + other.name);
        if (other.gameObject.CompareTag("Spike")) 
        {
            SceneManager.LoadScene("GameOver");
        };
        // GameManagerDependencyInfo.FinishedGame(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if (damageCollider == true)
        //{
        //    SceneManager.LoadScene("GameOver");
        
    }

}
//