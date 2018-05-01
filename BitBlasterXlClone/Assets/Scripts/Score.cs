using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int currentScore;

    public Text scoreText;

    public void RaiseScore(int points) {
        currentScore += points;
    }

    private void FixedUpdate() {
        scoreText.text = currentScore.ToString();
    }
}
