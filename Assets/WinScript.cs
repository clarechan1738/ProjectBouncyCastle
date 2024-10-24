using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

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