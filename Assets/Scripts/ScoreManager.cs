using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerScore.currScore.ToString();
        highscoreText.text = "HIGHSCORE: " + HighScore.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public static int getScore(){
    //     return score;
    // }

    public void newGame(){
        PlayerScore.currScore = 0;
    }

    public void updateScore(){
        PlayerScore.currScore += 10;
        scoreText.text = "Score: " + PlayerScore.currScore.ToString();
    }

    public void updateHighScore(){
        
        if(PlayerScore.currScore > HighScore.highScore){
            HighScore.highScore = PlayerScore.currScore;

        }
        highscoreText.text = "HIGHSCORE: " + HighScore.highScore.ToString();
    }
}
