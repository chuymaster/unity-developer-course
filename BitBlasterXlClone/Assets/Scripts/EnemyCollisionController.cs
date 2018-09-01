using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour {

    Enemies enemiesScript;

	private void Awake()
	{
        GameObject gb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        enemiesScript = gb.GetComponent<Enemies>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Outer Border") {
            enemiesScript.currentEnemiesAmount--;
            Destroy(this.transform.parent.gameObject);
        }
	}
}
