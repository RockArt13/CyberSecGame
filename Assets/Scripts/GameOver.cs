using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TMP_Text roundText;

    public SceneFade sceneFade;

    public string sceneName = "MainMenu";

    private void OnEnable()
    {
        roundText.text = PlayerState.Rounds.ToString();
    }

    public void Retry()
    {
        sceneFade.FadeTo(SceneManager.GetActiveScene().name);

    }

    public void Menu()
    {
        sceneFade.FadeTo(sceneName);
    }
}
