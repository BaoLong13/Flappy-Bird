using UnityEngine;

[CreateAssetMenu(fileName = "SaveData")]
public class SaveData : ScriptableObject
{
    public int currStage;
    private void SetDefault()
    {
        currStage = 0;
    }
    public SaveData()
    {
        SetDefault();
    }    
}
