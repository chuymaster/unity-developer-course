using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHealth;

    public CollectionController collectionController;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "InnerBorder")
        {
            playerHealth.DestroyShip();
        }
        else if (collision.gameObject.tag == "EnemyCollider")
        {
            playerHealth.TakeDamage();
        }
        else if (collision.gameObject.tag == "Collectable")
        {
            collectionController.Collect(collision.gameObject);
        }
	}

	// Use this for initialization
	void Start () {
        player = this.transform.parent.gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
