using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMechanics : MonoBehaviour {

    Minefield minefield;
    SpriteController spriteController;
    Tile tile;

	// Use this for initialization
	void Start () {
        // Find gameobject outside its scope
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();

        // Get component from self's gameobject
        spriteController = GetComponent<SpriteController>();
        tile = GetComponent<Tile>();
    }

    private void OnMouseUpAsButton()
    {
        ClickTile();
    }

    void OnMouseOver()
    {
        // Check right click
        if (Input.GetMouseButtonDown(1)) {
            if (tile.isSecured) {
                spriteController.SetDefaultTileSprite();
                tile.isSecured = false;
                minefield.minesLeft++;
            } else {
                spriteController.SetSecuredTileSprite();
                tile.isSecured = true;
                minefield.minesLeft--;
            }
        }
    }


    void ClickTile(){
        // Check if game started
        if (!minefield.hasGameStarted) {
            minefield.hasGameStarted = true;

            this.CreateMines();
            minefield.timer.StartTimer();
        }

        if (tile.isMine) {
            minefield.LoseGame();
        } else {
            RevealTile();

            if (minefield.IsGameWon()) {
                minefield.WinGame();
            }
        }
    }

    void CreateMines(){
        Debug.Log("Create Mines");

        int minesLeft = minefield.amountMines;
        int tilesLeft = minefield.amountTilesUnrevealed;

        for (int x = 0; x < minefield.xTotal; x++) {
            for (int y = 0; y < minefield.yTotal; y++) {
                // Prevent from creating bomb at the first click
                if (!(x == tile.x && y == tile.y)){
                    
                    Tile aTile = minefield.tiles[x, y];

                    // Chance for mine will increase as tiles left go down.
                    float chanceForMine = (float)minesLeft / (float)tilesLeft;

                    if (Random.value <= chanceForMine) {
                        aTile.isMine = true;
                        minesLeft--;
                    }
                }
                tilesLeft--;
            }
        }
    }    

    public void RevealTile(){
        
        // Reveal tile without bomb
        if (!tile.isRevealed && !tile.isMine) {
            tile.isRevealed = true;
            minefield.amountTilesUnrevealed--;

            int amountNeighbourMines = GetAmountNeighborMines();
            spriteController.SetEmptyTireSprite(amountNeighbourMines);

            if (amountNeighbourMines == 0) {
                RevealIfValid(tile.x - 1, tile.y - 1);
                RevealIfValid(tile.x - 1, tile.y);
                RevealIfValid(tile.x - 1, tile.y + 1);
                RevealIfValid(tile.x, tile.y - 1);
                RevealIfValid(tile.x, tile.y + 1);
                RevealIfValid(tile.x + 1, tile.y - 1);
                RevealIfValid(tile.x + 1, tile.y);
                RevealIfValid(tile.x + 1, tile.y + 1);
            }
        }

    }

    void RevealIfValid(int x, int y){
        // avoid x/y out of range
        if( x >= 0 && x < minefield.xTotal
           && y>= 0 && y < minefield.yTotal) {
            // The tile will call this ClickMechanics's RevealTile() method.
            // In loop until there is no tile without bomb in neightbour
            minefield.tiles[x, y].clickMechanics.RevealTile();
        }
    }

    public int GetAmountNeighborMines(){
        int mineCounter = 0;

        if (HasMine(tile.x - 1, tile.y - 1)) mineCounter++;
        if (HasMine(tile.x - 1, tile.y)) mineCounter++;
        if (HasMine(tile.x - 1, tile.y + 1)) mineCounter++;
        if (HasMine(tile.x, tile.y - 1)) mineCounter++;
        if (HasMine(tile.x, tile.y + 1)) mineCounter++;
        if (HasMine(tile.x + 1, tile.y - 1)) mineCounter++;
        if (HasMine(tile.x + 1, tile.y)) mineCounter++;
        if (HasMine(tile.x + 1, tile.y + 1)) mineCounter++;

        return mineCounter;
    }

    bool HasMine(int x, int y)
    {
        bool hasMine = false;

        if (x >= 0 && x < minefield.xTotal && y >= 0 && y < minefield.yTotal)
        {
            hasMine = minefield.tiles[x, y].isMine;
        }

        return hasMine;
    }

}
