using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

    public Sprite defaultSprite;
    public Sprite mineSprite;
    public Sprite securedTireSprite;
    public Sprite deadlyMineSprite;
    public Sprite securedMineSprite;
    public Sprite[] emptyTireSprites;

    private void Start()
    {
        //SetEmptyTireSprite(1);
    }

    public void SetEmptyTireSprite(int amountNeighbouredMines) {
        GetComponent<SpriteRenderer>().sprite = emptyTireSprites[amountNeighbouredMines];
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetMineSprite() {
        GetComponent<SpriteRenderer>().sprite = mineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetSecuredTileSprite()
    {
        GetComponent<SpriteRenderer>().sprite = securedTireSprite; // Mark that this may be a bomb
    }


    public void SetDeadlyMineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = deadlyMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetSecuredMineSprite()
    {
        GetComponent<SpriteRenderer>().sprite = securedMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetDefaultTileSprite()
    {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }
}
