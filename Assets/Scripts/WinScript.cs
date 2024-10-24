using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
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
        if (other.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (other.gameObject.CompareTag("Winner"))
        {
            SceneManager.LoadScene("Winner");
        }
        else if (other.gameObject.CompareTag("Lvl1"))
        {
            SceneManager.LoadScene("Level 1");
            camClone = Instantiate(Part2Camera, cameraSpawnLocation.transform.position, Quaternion.identity);
            transform.position = camClone.transform.position + new Vector3(0, 1, -5);
            Destroy(gameObject);

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