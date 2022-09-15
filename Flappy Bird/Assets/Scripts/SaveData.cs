using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData")]
public class SaveData : ScriptableObject
{
    public int currStage;
    private void SetDefault()
    {
        currStage = 0;
    }
}
