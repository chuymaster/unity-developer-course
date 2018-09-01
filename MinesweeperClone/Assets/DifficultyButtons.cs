using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{


    Minefield minefield;

    public string currentDifficulty = "easy";

    // Use this for initialization
    void Start()
    {
        this.minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        SetEasy();
    }

    public void SetEasy()
    {
        minefield.CreateMineField(10, 10, 2);
        currentDifficulty = "easy";
    }

    public void SetMedium()
    {
        minefield.CreateMineField(20, 20, 40);
        currentDifficulty = "medium";
    }

    public void SetHard()
    {
        minefield.CreateMineField(30, 30, 90);
        currentDifficulty = "hard";
    }

    public void ResetGame()
    {
        if (this.currentDifficulty == "easy")
        {
            SetEasy();
        }
        else if (this.currentDifficulty == "medium")
        {
            SetMedium();
        }else{
            SetHard();
        }
    }
}
