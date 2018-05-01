using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Text highScoreText;
    public int highScoreInt;

	public void Awake()
	{
        if (PlayerPrefs.HasKey("highscore")) {
            this.highScoreInt = PlayerPrefs.GetInt("highscore");
        } else {
            highScoreInt = 0;
            PlayerPrefs.SetInt("highscore", highScoreInt);
        }

        highScoreText.text = "High Score: " + highScoreInt.ToString();
	}

    public void OnPlayClick() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitApplication() {
        Application.Quit();
    }
}
