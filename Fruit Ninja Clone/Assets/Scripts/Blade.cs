using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public float minVelo = 0.1f;

    private Rigidbody2D rb;
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;

    private Collider2D col;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        // Enable collusion only if mouse moving.
        // Not moving mouse = no collider = no cutting fruits.
        col.enabled = IsMouseMoving();

        SetBladeToMouse();
	}

    private void SetBladeToMouse(){

        // Workaround to get mousePosition work in 2D world
        var mousePos = Input.mousePosition;
        mousePos.z = 10; // Opposite of Z value of camera Z position

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMoving(){
        
        Vector3 curMousePos = transform.position;
        // line length between 2 vectors
        float traveled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;

        // If traveled more than value, consider moving
        if (traveled > minVelo) {
            return true;
        }else{
            return false;
        }
    }
}
