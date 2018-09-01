using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameButton : MonoBehaviour {

    public Sprite happyFace;
    public Sprite neutralFace;
    public Sprite sadFace;

    public Button resetButton;

    public void SetHappy() {
        resetButton.image.sprite = happyFace;
    }

    public void SetNeutral()
    {
        resetButton.image.sprite = neutralFace;
    }

    public void SetSad()
    {
        resetButton.image.sprite = sadFace;
    }


}
