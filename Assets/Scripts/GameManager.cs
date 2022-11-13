using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameOver;

    public GameObject gameOverUI;

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
}
