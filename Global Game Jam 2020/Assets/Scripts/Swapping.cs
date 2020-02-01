using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swapping : MonoBehaviour
{
    public GameObject[] players;

    bool canSwap = true;
    public float timeBetweenSwap;
    public float timeBetweenSwapCounter;

    public Image timerBar;

    void Start()
    {
        timeBetweenSwapCounter = timeBetweenSwap;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player1Position;
        Vector2 player2Position;

        if (Input.GetKeyDown(KeyCode.B) && canSwap == true)
        {
            timerBar.fillAmount = 0;
            timeBetweenSwapCounter = timeBetweenSwap;
            player1Position = players[0].transform.position;
            player2Position = players[1].transform.position;
            players[0].transform.position = player2Position;
            players[1].transform.position = player1Position;
            canSwap = false;
        }
        if (timeBetweenSwapCounter > 0 && canSwap == false)
        {
            timeBetweenSwapCounter -= Time.deltaTime;
            timerBar.fillAmount = 1 - timeBetweenSwapCounter / timeBetweenSwap;
            if (timeBetweenSwapCounter < 0)
            {
                timerBar.fillAmount = 1;
                canSwap = true;
            }
        }
        if (timeBetweenSwapCounter == 0 && canSwap == false)
        {
            canSwap = true; 
            timerBar.fillAmount = 1;
        }
    }
}
