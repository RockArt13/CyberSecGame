using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public SceneFade sceneFade;

    public string sceneName = "MainMenu";

    public void Retry()
    {
        sceneFade.FadeTo(SceneManager.GetActiveScene().name);

    }

    public void Menu()
    {
        sceneFade.FadeTo(sceneName);
    }
}
