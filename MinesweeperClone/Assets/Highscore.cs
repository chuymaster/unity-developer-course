using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    public int highscoreEasy;
    public int highscoreMedium;
    public int highscoreHard;

    public Text highscoreText;

    public DifficultyButtons difficultyButtons;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("HighScoreEasy"))    {
            highscoreEasy = PlayerPrefs.GetInt("HighscoreEasy");
        }else {
            highscoreEasy = 999;
        }
        if (PlayerPrefs.HasKey("HighScoreMedium"))
        {
            highscoreMedium = PlayerPrefs.GetInt("HighScoreMedium");
        } else {
            highscoreMedium = 999;
        }
        if (PlayerPrefs.HasKey("HighScoreHard"))
        {
            highscoreHard = PlayerPrefs.GetInt("HighScoreHard");
        }else {
            highscoreHard = 999;
        }
	}

    void FixedUpdate () {
        switch (difficultyButtons.currentDifficulty)
        {
            case "easy":
                highscoreText.text = highscoreEasy.ToString();
                break;
            case "medium":
                highscoreText.text = highscoreMedium.ToString();
                break;
            case "hard":
                highscoreText.text = highscoreHard.ToString();
                break;
        }
    }

    public void UpdateHighscore(int score){
        switch (difficultyButtons.currentDifficulty)
        {
            case "easy":
                if (score < highscoreEasy)
                {
                    highscoreEasy = score;
                    PlayerPrefs.SetInt("HighScoreEasy", score);
                }

                break;
            case "medium":
                if (score < highscoreMedium)
                {
                    highscoreMedium = score;
                    PlayerPrefs.SetInt("HighScoreMedium", score);
                }

                break;
            case "hard":
                if (score < highscoreHard)
                {
                    highscoreHard = score;
                    PlayerPrefs.SetInt("HighScoreHard", score);
                }

                break;
        }

        PlayerPrefs.Save();
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        highscoreEasy = 999;
        highscoreMedium = 999;
        highscoreHard = 999;
    }
}
