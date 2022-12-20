using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinished : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public SceneFade sceneFade;

    public string nextLevel = "Level02";
    public int levelCheckPoint = 2;

    public void Contonie()
    {
        PlayerPrefs.SetInt("levelCheckPoint", levelCheckPoint);
        sceneFade.FadeTo(nextLevel);
    }
    public void Menu()
    {
        sceneFade.FadeTo(menuSceneName);
    }
}
