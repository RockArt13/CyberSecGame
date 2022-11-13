using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TMP_Text roundText;

    private void OnEnable()
    {
        roundText.text = PlayerState.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Menu()
    {
        Debug.Log("Main Menu!");
    }
}
