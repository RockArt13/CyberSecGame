using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "SampleScene";
   public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Exit()
    {
        Debug.Log("Quiting!");
        Application.Quit();
    }
}
