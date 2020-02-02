using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //PauseControl
    public static bool GameIsPaused = false;
    public static bool pause = false; //2eme variable pour savoir si on a quitté la scene de jeu

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject choiceMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        choiceMenuUI.SetActive(false);
        Time.timeScale = 1f; //resume time
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //freeze time
        GameIsPaused = true;
        pause = true; 
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); //load the previous scene
        FindObjectOfType<AudioManager>().Stop(PlayerPrefs.GetInt("LevelIndice", 0).ToString());
        pause = false;
    }

    public void Restart()
    {
        //FindObjectOfType<ScoreTest>().score1.text = 0.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        FindObjectOfType<AudioManager>().Stop(PlayerPrefs.GetInt("LevelIndice", 0).ToString());
        FindObjectOfType<AudioManager>().Play(PlayerPrefs.GetInt("LevelIndice", 0).ToString());

        pause = false;

        Time.timeScale = 1f;
    }
}
