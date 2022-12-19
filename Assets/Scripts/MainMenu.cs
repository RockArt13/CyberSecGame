using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "SampleScene";

    public SceneFade sceneFade;
   public void Play()
    {
        sceneFade.FadeTo(levelToLoad);
    }

    public void Exit()
    {
        Debug.Log("Quiting!");
        Application.Quit();
    }
}
