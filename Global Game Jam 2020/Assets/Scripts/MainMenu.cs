using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
        //FindObjectOfType<AudioManager>().Stop("MainTheme");
    }
}
