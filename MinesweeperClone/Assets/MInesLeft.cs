using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MInesLeft : MonoBehaviour {

    Minefield mineField;

    public Text minesLeftText; 

	// Use this for initialization
	void Start () {
        mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
	}

    private void FixedUpdate()
    {
        minesLeftText.text = mineField.minesLeft.ToString();
    }
}
