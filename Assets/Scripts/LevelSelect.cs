using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public SceneFade fade;

    public Button[] levelButtons;

    private void Start()
    {
        int levelCheckPoint = PlayerPrefs.GetInt("levelCheckPoint", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i+1 > levelCheckPoint)
            levelButtons[i].interactable = false;
        }
    }

    public void Select(string levelName)
    {
        fade.FadeTo(levelName);

    }
}
