using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour {

    Minefield minefield;

    // Use this for initialization
    void Start()
    {
        this.minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Go up for the amount of y mines
        this.transform.position = new Vector2(0, (this.minefield.yTotal - 1f) / 2f + 2f);

        RectTransform rectTrans = (RectTransform)this.transform;
        // Fixed height but stretch X.
        rectTrans.sizeDelta = new Vector2(this.minefield.xTotal + 3, 3);
    }
}
