using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    //Current Checkpoint Player Has Hit
    int currentCheckpoint = 0;

    //Reference To SaveFile Script
    SaveFile saveScript;

    //Actual Player Object
    public GameObject player;

    //Checkpoints
    [Header("Checkpoints")]
    public Vector3[] checkPoint = new Vector3[4];


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
            player.transform.position = checkPoint[currentCheckpoint];
        }
        else
        {
            saveScript.SaveToJSON();
            player.transform.position = checkPoint[currentCheckpoint];
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
