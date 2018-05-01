using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour {

    [Header("Bullet")]
    public float shootingSpeed;
    public float bulletSpeed;
    public int amountAmmo;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public Transform spawnPoint;
    public Text ammoText;

    float nextShot = 0;

    //TODO: Add Text UI
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.Space) && Time.time > nextShot && amountAmmo > 0) {
            Shoot();
        }

	}

	private void FixedUpdate()
	{
        ammoText.text = this.amountAmmo.ToString();
	}

	void Shoot(){
        // Increase time
        nextShot = Time.time + shootingSpeed;

        GameObject newBullet = GameObject.Instantiate(playerBulletPrefab, spawnPoint.position, spawnPoint.rotation);
        newBullet.transform.parent = bullets.transform;

        Rigidbody2D newBulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        newBulletRigidBody.AddForce(transform.up * bulletSpeed);

        amountAmmo--;
    }


}
