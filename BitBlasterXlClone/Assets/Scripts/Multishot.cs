using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multishot : MonoBehaviour {

    [Header("Bullet")]
    public float shootingSpeed;
    public float bulletSpeed;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public Transform[] multiShotSpawnPoints;

    float nextShot = 0;


    public void ShootRepeating() {

        if (Time.time > nextShot + shootingSpeed) {

            // Increase time
            nextShot = Time.time;

            foreach (Transform spawnPoint in multiShotSpawnPoints)
            {

                GameObject newBullet = GameObject.Instantiate(playerBulletPrefab, spawnPoint.position, spawnPoint.rotation);
                newBullet.transform.parent = bullets.transform;

                Rigidbody2D newBulletRigidBody = newBullet.GetComponent<Rigidbody2D>();

                // Get direction difference between spawn point and gameobject to ยิงเฉียงๆ
                Vector3 dir = (spawnPoint.transform.position - gameObject.transform.position).normalized;

                newBulletRigidBody.AddForce(dir * bulletSpeed);

            }
        }

    }
}
