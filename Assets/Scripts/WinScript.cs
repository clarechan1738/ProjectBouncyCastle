using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject cameraSpawnLocation;
    public GameObject Part2Camera;
    private GameObject camClone;
    public GameObject mainCamera;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided With" + other.name);
        if (other.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (other.gameObject.CompareTag("Winner"))
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (other.gameObject.CompareTag("Lvl2"))
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (other.gameObject.CompareTag("FinishWall"))
        {
            SceneManager.LoadScene("Winner");
            print("WinnerWallTouched");
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