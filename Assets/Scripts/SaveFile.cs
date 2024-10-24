using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile : MonoBehaviour
{

    //New Instance Of The Save File
    private FileData save = new FileData();

    //Saves The Information To A JSON File
    public void SaveToJSON()
    {
        string data = JsonUtility.ToJson(save);
        System.IO.Directory.CreateDirectory(Application.dataPath + "/SaveFiles");
        System.IO.File.WriteAllText(Application.dataPath + "/SaveFiles/SaveGame.json", data);
    }

    //Loads Data If It Exists
    public bool LoadFromJSON()
    {
        bool exists = false;

        if (System.IO.File.Exists(Application.dataPath + "/SaveFiles/SaveGame.json"))
        {
            string data = System.IO.File.ReadAllText(Application.dataPath + "/SaveFiles/SaveGame.json");
            save = JsonUtility.FromJson<FileData>(data);
            exists = true;
        }
        else
        {
            SetCheckpoint(0);
            SaveToJSON();
        }

        return exists;
    }

    
    public void SetCheckpoint(int checkpoint)
    {
        save.checkpointHit = checkpoint;
    }

    public int GetCheckpoint()
    {
        return save.checkpointHit;
    }

}



[System.Serializable]
public class FileData
{
    public int checkpointHit;
}
