using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public Vector3 movementDirection;
    public float movementSpeed;

    private void Start()
    {
        //movementDirection = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
	}
}
