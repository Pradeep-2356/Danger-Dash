using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Level Passed")]
[SerializeField] private GameObject levelPassedScreen;
[SerializeField] private AudioClip levelPassedSound;


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        levelPassedScreen.SetActive(false);
    }
    private void Update()
{
    // Prevent pause menu if Game Over or Level Passed screen is active
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (!gameOverScreen.activeInHierarchy && !levelPassedScreen.activeInHierarchy)
        {
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }
}

    #region Game Over
    //Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
       
    }

    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status){

            Time.timeScale = 0;
            SoundManager.instance.MuteGameplayAudio();
        }
        else{

            Time.timeScale = 1;
            SoundManager.instance.UnmuteGameplayAudio();
        }
    }
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion

    #region 
    // Load next level
// Load next level
public void LevelPassed()
{
    // Activate the level passed screen
    if (levelPassedScreen != null){
        levelPassedScreen.SetActive(true);
        SoundManager.instance.PlaySound(levelPassedSound); 
        SoundManager.instance.MuteGameplayAudio();
    }

}

// Coroutine to delay level load
public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels. Returning to Main Menu.");
            SceneManager.LoadScene(0);
        }
    }


    #endregion
}