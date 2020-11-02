using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static int score;
    public static int health = 50;

    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject winner;
    public GameObject loser;

    public GameObject player;

    //keep track of current level
    private string CurrentLevelName = string.Empty;

/*    #region This code makes this class a singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //make sure game manager persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" +
                "instance of singleton Game Manager");
        }
    }
    #endregion*/

    //methods to load and unload scenes
    public void LoadLevel(string LevelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level " + LevelName);
            return;
        }
        CurrentLevelName = LevelName;
        winner.SetActive(false);
        loser.SetActive(false);
    }

    public void UnloadLevel(string LevelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(LevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to unload level " + LevelName);
            return;
        }
        CurrentLevelName = LevelName;
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to unload level " + CurrentLevelName);
            return;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if (score >= 5)
        {
            UnloadCurrentLevel();
            winner.SetActive(true);
            mainMenu.SetActive(true);
        }
        if (health <= 0)
        {
            UnloadCurrentLevel();
            loser.SetActive(true);
            mainMenu.SetActive(true);
        }
    }

}
