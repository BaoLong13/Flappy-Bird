using UnityEngine;
using System.IO;

public class SaveModule : MonoBehaviour
{
    public static SaveModule instance;

    private void Awake()
    {
        instance = this;
    }

    private void CheckIfExists()
    {
        string path = Application.persistentDataPath + "/SaveData.txt";

        if (!File.Exists(path))
        {
            File.CreateText(path).Close();
        }
    }

    public void SaveData(SaveData data)
    {
        string savePath = Application.persistentDataPath + "/SaveData.txt";
        string json = JsonUtility.ToJson(data);
        CheckIfExists();

        StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public void LoadData(SaveData data)
    {
        string savePath = Application.persistentDataPath + "/SaveData.txt";
        CheckIfExists();

        StreamReader reader = new StreamReader(savePath);
        string json = reader.ReadToEnd();
        reader.Close();
        JsonUtility.FromJsonOverwrite(json, data);
        UIManager.instance.currStage = data.currStage;
    }    
}
