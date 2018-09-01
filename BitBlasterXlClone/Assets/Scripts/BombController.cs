using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public int amountBombs;

    public GameObject[] bombSprites;
    public GameObject enemiesGameObject;
    public GameObject bulletsGameObject;

	// Use this for initialization
	void Start () {
        int startingNukesAmount = 5;
        amountBombs = startingNukesAmount;


	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z)){
            IgniteNuke();
        }
	}

	private void FixedUpdate()
	{
        for (int i = 0; i < 5; i++) {
            // Check for amount of bomb and set sprites active/inactive
            if (i < amountBombs) {
                bombSprites[i].SetActive(true);
            } else {
                bombSprites[i].SetActive(false);
            }
        }


	}

    void IgniteNuke() {
        
        if (amountBombs > 0) {
            
            // Loop through enemy in enemies and destroy all of them
            foreach (Transform enemy in enemiesGameObject.transform) {
                EnemyDestroyController enemyDestroyController = enemy.GetComponent<EnemyDestroyController>();
                enemyDestroyController.DestroyByPlayer();
            }

            foreach (Transform bullet in bulletsGameObject.transform) {
                Destroy(bullet);
            }

            amountBombs--;
        }
    }

}
