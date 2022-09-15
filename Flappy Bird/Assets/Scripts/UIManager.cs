using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject retryPanel;
    public GameObject nextPanel;
    public TMP_Text textMeshPro;

    public int currScore;
    public int currStage;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        currScore++;
        CheckScore();
    }

    public void CheckScore()
    {
        if (currScore == 3)
        {
            GameManager.instance.ChangeState(GameState.EndStage);
        }
    }

    public void UpdateStageData()
    {
        textMeshPro.text = currStage.ToString();
    }

    public void PopUp(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void PopDown(GameObject panel)
    {
        panel.SetActive(false);
        GameManager.instance.ChangeState(GameState.StartStage);
    }
}
