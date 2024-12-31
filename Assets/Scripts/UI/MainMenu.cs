using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayInfo()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayInfo2()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}

