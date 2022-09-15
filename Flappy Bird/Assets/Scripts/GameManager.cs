using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;
    public GameObject bird;
    public SaveData saveData;
    
    private void Awake()
    {
        instance = this;
    }

    private void OnApplicationQuit()
    {
        SaveModule.instance.SaveData(saveData);
    }

    private void Start()
    {
        ChangeState(GameState.StartStage);
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.StartStage:
                Time.timeScale = 1;
                SaveModule.instance.LoadData(saveData);
                UIManager.instance.UpdateStageData();
                bird.GetComponent<Bird>().ResetBird();
                UIManager.instance.currScore = 0;
                Spawner.instance.ResetSpawn();
                Spawner.instance.RandomSpawn();
                break;
            case GameState.EndStage:
                UIManager.instance.PopUp(UIManager.instance.nextPanel);
                UIManager.instance.currScore = 0;
                UIManager.instance.currStage += 1;
                saveData.currStage = UIManager.instance.currStage;
                SaveModule.instance.SaveData(saveData);
                Debug.Log(UIManager.instance.currStage);
                Time.timeScale = 0;
                break;
            case GameState.Death:
                bird.GetComponent<Bird>().KillBird();
                bird.GetComponent<Bird>().ResetBird();
                UIManager.instance.currScore = 0;
                UIManager.instance.currStage = 0;
                saveData.currStage = UIManager.instance.currStage;
                SaveModule.instance.SaveData(saveData);
                UIManager.instance.PopUp(UIManager.instance.retryPanel);
                Time.timeScale = 0;
                break;
        }
    }
}

public enum GameState
{
    StartStage = 0,
    EndStage = 1,
    Death = 2,
}
