using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour {

    public int pointsOnPlayerDestruction;

    public bool isSplitter = false;

    Collectables collectables;

    Score score;

    Enemies enemiesScript;

	void Awake()
	{
        GameObject gb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        enemiesScript = gb.GetComponent<Enemies>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

        collectables = GameObject.FindGameObjectWithTag("Collectables").GetComponent <Collectables> ();
	}

    public void DestroyByPlayer() {
        Debug.Log("Destroyed by the player");

        score.RaiseScore(pointsOnPlayerDestruction);

        collectables.SpawnRandomCollectable(transform);

        enemiesScript.currentEnemiesAmount--;
        Destroy(this.gameObject);
    }   
}
