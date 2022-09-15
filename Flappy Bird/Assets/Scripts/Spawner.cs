using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public List<GameObject> gameObjects = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void RandomSpawn()
    {
        int randomIndex = Random.Range(0, gameObjects.Count);
        gameObjects[randomIndex].SetActive(true);
    }

    public void ResetSpawn()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }
}
