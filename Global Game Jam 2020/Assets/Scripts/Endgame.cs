using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : ActiveObject
{

    private void Update()
    {
        if (State)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
