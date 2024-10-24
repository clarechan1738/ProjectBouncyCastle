using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    //Current Checkpoint Player Has Hit
    int currentCheckpoint = 0;

    //Reference To SaveFile Script
    SaveFile saveScript;

    //Clone Of Player Object
    private GameObject playerClone;

    //Actual Player Object
    public GameObject player;

    //Checkpoints
    [Header("Checkpoints")]
    public GameObject[] checkPoint = new GameObject[4];


    private void Awake()
    {
        saveScript = FindAnyObjectByType<SaveFile>();
    }

    private void Start()
    {

        //Loads The Game
        LoadGame();
    }

    public void LoadGame()
    {
        if (saveScript.LoadFromJSON())
        {
            currentCheckpoint = saveScript.GetCheckpoint();
            playerClone = Instantiate(player, checkPoint[saveScript.GetCheckpoint()].transform.position, Quaternion.identity);
        }
        else
        {
            saveScript.SaveToJSON();
            playerClone = Instantiate(player, checkPoint[saveScript.GetCheckpoint()].transform.position, Quaternion.identity);
            playerClone.transform.eulerAngles = Vector3.zero;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
         //Compares The Checkpoint Tag
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            //Checks Which Checkpoint They Are Hitting
            switch (currentCheckpoint)
            {
                //Sets The Checkpoint To Whatever Was Hit & Saves To The SaveFile.
                case 0:
                    Destroy(other.gameObject);
                    currentCheckpoint = 1;
                    saveScript.SetCheckpoint(1);
                    saveScript.SaveToJSON();
                    break;
                case 1:
                    Destroy(other.gameObject);
                    currentCheckpoint = 2;
                    saveScript.SetCheckpoint(2);
                    saveScript.SaveToJSON();
                    break;
                case 2:
                    Destroy(other.gameObject);
                    currentCheckpoint = 3;
                    saveScript.SetCheckpoint(3);
                    saveScript.SaveToJSON();
                    break;
                case 3:
                    Destroy(other.gameObject);
                    currentCheckpoint = 4;
                    saveScript.SetCheckpoint(4);
                    saveScript.SaveToJSON();
                    break;
            }
        }
    }

}

