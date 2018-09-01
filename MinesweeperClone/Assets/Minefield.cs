using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minefield : MonoBehaviour {

    public int amountMines;
    public int amountTilesUnrevealed;
    public bool hasGameStarted = false;

    public int xTotal;
    public int yTotal;

    // 2D array
    public Tile[,] tiles;

    public Timer timer;
    public ResetGameButton resetGameButton;
    public int minesLeft = 0;

    public Highscore highscore;

    public void CreateMineField(int xTotal, int yTotal, int amountMines) {

        // Assign value to self
        this.xTotal = xTotal;
        this.yTotal = yTotal;
        this.amountMines = amountMines;
        this.amountTilesUnrevealed = xTotal * yTotal; // All tiles are unrevealed at the beginning
        this.hasGameStarted = false;

        // Reset UIs
        this.minesLeft = amountMines;
        this.timer.ResetTimer();
        this.resetGameButton.SetNeutral();

        if (this.tiles != null) {
            foreach (Tile tile in this.tiles) {
                Destroy(tile.gameObject);
            }
        }

        // Build new tiles
        this.tiles = new Tile[xTotal, yTotal];

        for (int x = 0; x < xTotal; x++) {
            for (int y = 0; y < yTotal; y++) {
                tiles[x, y] = Tile.CreateNewTile(x, y);
            }
        }
            
    }

    public bool IsGameWon() {
        // All unrevealed are mines = win!
        if (amountTilesUnrevealed == amountMines) {
            return true;
        } else {
            return false;
        }
    }

    public void LoseGame() {
        Debug.Log("YOU LOSE");

        timer.StopTimer();
        resetGameButton.SetSad();

        foreach (Tile tile in this.tiles)
        {
            if (!tile.isMine)
            {
                tile.GetComponent<BoxCollider2D>().enabled = false;
            } else {
                tile.spriteController.SetMineSprite();
            }
        }
    }

    public void WinGame() {
        Debug.Log("WIN GAME");

        timer.StopTimer();
        resetGameButton.SetHappy();

        foreach(Tile tile in this.tiles) {
            if (tile.isMine) {
                tile.spriteController.SetSecuredMineSprite();
            }
        }

        highscore.UpdateHighscore(timer.GetCurrentTime());
    }

	// Use this for initialization
	void Start () {
	}
}
