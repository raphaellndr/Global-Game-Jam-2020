using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public Text orderCounterText;
    public Sprite GoldenStar, EmptyStar;
    public Image leftStar, middleStar, rightStar;

    void OnEnable()
    {
        score = PlayerPrefs.GetInt("CurrentScore1", 0);
        scoreText.text = score.ToString();
        orderCounterText.text = "0";
        if(score<10)
        {
            leftStar.sprite = EmptyStar;
            middleStar.sprite = EmptyStar;
            rightStar.sprite = EmptyStar;
        }
        else if(score<50)
        {
            leftStar.sprite = GoldenStar;
            middleStar.sprite = EmptyStar;
            rightStar.sprite = EmptyStar;
        }
        else if (score < 200)
        {
            leftStar.sprite = GoldenStar;
            middleStar.sprite = GoldenStar;
            rightStar.sprite = EmptyStar;
        }
        else 
        {
            leftStar.sprite = GoldenStar;
            middleStar.sprite = GoldenStar;
            rightStar.sprite = GoldenStar;
        }
    }
}
