using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    public GameObject powerUpLaser;
    public GameObject powerUpMultishot;
    public GameObject powerUpBerserk;

    public GameObject resourceAmmo;
    public GameObject resourceShield;
    public GameObject resourceBomb;

    public float powerUpSpawnChance = 0.1f;

    public void SpawnRandomCollectable(Transform pos) {
        float v = Random.value;
        if (v < powerUpSpawnChance) {
            SpawnRandomPowerUp(pos);
        } else {
            SpawnRandomResource(pos);
        }
    }

    private void SpawnRandomPowerUp(Transform pos) {
        float v = Random.value;

        Collectable newCollectable;

        if (v > 0.5) {
            newCollectable = Collectable.CreateMultishot();
        } else if (v > 0.2f) {
            newCollectable = Collectable.CreateBerserk();
        } else {
            newCollectable = Collectable.CreateLaser();
        }

        newCollectable.gameObject.transform.position = pos.position;
    }

    private void SpawnRandomResource(Transform pos)
    {
        float v = Random.value;

        Collectable newCollectable;

        if (v > 0.1f)
        {
            newCollectable = Collectable.CreateAmmo();
        }
        else if (v > 0.05f)
        {
            newCollectable = Collectable.CreateBomb();
        }
        else
        {
            newCollectable = Collectable.CreateShield();
        }

        newCollectable.gameObject.transform.position = pos.position;
    }
}
