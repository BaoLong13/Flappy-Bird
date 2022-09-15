using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveModule : MonoBehaviour
{
    public static SaveModule instance;
    private string persistentDataPath;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        persistentDataPath = Application.persistentDataPath;
    }

    private void CheckIfExists()
    {
        string path = persistentDataPath + "/SaveData.txt";

        if (!File.Exists(path))
        {
            File.CreateText(path).Close();
        }
    }

    public void SaveData(SaveData data)
    {
        string savePath = persistentDataPath + "/SaveData.txt";
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        CheckIfExists();

        StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public void LoadData(SaveData data)
    {
        string savePath = persistentDataPath + "/SaveData.txt";
        CheckIfExists();

        StreamReader reader = new StreamReader(savePath);
        string json = reader.ReadToEnd();
        reader.Close();
        JsonUtility.FromJsonOverwrite(json, data);
        UIManager.instance.currStage = data.currStage;
    }    
}
