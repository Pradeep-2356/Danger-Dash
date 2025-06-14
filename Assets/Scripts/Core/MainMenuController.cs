using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Call this from the Play button's OnClick() event
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Load Level 1 (scene index 1)
    }

    // Call this from the Quit button's OnClick() event
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}
