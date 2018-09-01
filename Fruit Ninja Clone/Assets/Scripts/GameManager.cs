using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    [Header("Score Elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("GameOver Elements")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;

    private void Awake() {

        // App ID For Android
        Advertisement.Initialize("1751248");

        gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "Best: " + highScore.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    public void IncreaseScore(int amount) {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
        if (score > highScore) {
            PlayerPrefs.SetInt("Highscore", score);
            highScore = score;
            highScoreText.text = "Best: " + highScore.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanel.SetActive(true);
        Advertisement.Show();
    }

    public void RestartGame() {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanel.SetActive(false);

        // Destroy all interactable objects
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable")) {
            Destroy(g);
        }

        Time.timeScale = 1;
    }

    public void PlayRandomSliceSound() {
        AudioClip audioClip = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(audioClip);
    }
}
