using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (other.gameObject.CompareTag("Winner"))
        {
            SceneManager.LoadScene("Winner");
        }
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