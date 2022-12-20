using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameOver;

    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int levelCheckPoint = 2;
    public SceneFade sceneFade;

    private void Start()
    {
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
            return;

        if(PlayerState.Lives<=0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Won!");
        PlayerPrefs.SetInt("levelCheckPoint", levelCheckPoint);
        sceneFade.FadeTo(nextLevel);
    }
}
