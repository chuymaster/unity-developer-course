using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int x;
    public int y;

    public bool isMine = false;
    public bool isRevealed = false;
    public bool isSecured = false;

    public ClickMechanics clickMechanics;
    public SpriteController spriteController;

    private void Start()
    {
        clickMechanics = GetComponent<ClickMechanics>();
        spriteController = GetComponent<SpriteController>();
    }

    public static Tile CreateNewTile(int x, int y) {

        // Create tile GameObject from Prefab
        GameObject tile = (GameObject)Instantiate(Resources.Load("Prefabs/Tile"));

        GameObject tiles = GameObject.FindGameObjectWithTag("Tiles");
        Minefield mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();

        // Set x, y from input value
        tile.GetComponent<Tile>().x = x;
        tile.GetComponent<Tile>().y = y;

        // Move parent to Tiles
        tile.transform.parent = tiles.transform;

        // Set position so that tiles are on top / right of each other
        tile.transform.position = new Vector2( (float)x - ((float)mineField.xTotal - 1f) / 2f, 
                                              (float)y - ((float)mineField.yTotal - 1f) / 2f);

        // Return Tile component
        return tile.GetComponent<Tile>();
    }
}
