using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public SceneFade fade;

    public void Select(string levelName)
    {
        fade.FadeTo(levelName);

    }
}
