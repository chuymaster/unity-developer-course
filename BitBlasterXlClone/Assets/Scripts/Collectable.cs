using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public float availableDuration;
    float killTime;

    public float blinkingTime;
    bool isBlinking = false;

    public CollectableType collectableType;

    SpriteRenderer collectableSprite;

	// Use this for initialization
	void Start () {

        // Set time to destroy this object
        killTime = Time.time + availableDuration;
        collectableSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
        
        if ((Time.time > killTime - blinkingTime) && !isBlinking) {
            StartCoroutine(this.Blink());
            isBlinking = true;
        }

        if (Time.time > killTime) {
            isBlinking = false;
            Destroy(gameObject);
        }

	}

    IEnumerator Blink() {
        for (int i = 0; i < 4; i ++) {
            // Disable/enable to create build effect
            collectableSprite.enabled = false;
            yield return new WaitForSeconds(0.25f);
            collectableSprite.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public static Collectable CreateAmmo() {

        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Ammo"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateShield()
    {

        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Shield"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateBomb()
    {

        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Bomb"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateMultishot()
    {

        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Multishot"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateLaser()
    {

        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Laser"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateBerserk()
    {

        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Berserk"));
        return ammo.GetComponent<Collectable>();
    }
}

public enum CollectableType {
    Ammo,
    Shield,
    Bomb,
    Multishot,
    Laser,
    Berserk
}