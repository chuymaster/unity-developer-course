using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour {

    public float basicDuration;
    public bool powerUpActive = true;
    public GameObject laser;
    public GameObject berserkAura;

    Multishot multishotScript;
    float activeUntilTime = 0;

    string powerUpType = "";

	// Use this for initialization
	void Start () {
        multishotScript = GetComponent<Multishot>();
        //ActivateMultishot();
        //ActivateLaser();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (powerUpActive && Time.time < activeUntilTime) {
            if (powerUpType == "multishot") {
                multishotScript.ShootRepeating();
            }else if (powerUpType == "laser") {
                laser.SetActive(true);
            }else if (powerUpType == "berserk") {
                berserkAura.SetActive(true);
            }
        } else {
            DeactivatePowerUp();
        }
	}

    public void DeactivatePowerUp() {
        powerUpType = null;
        powerUpActive = false;
        laser.SetActive(false);
        berserkAura.SetActive(false);
    }


    public void ActivateMultishot() {
        DeactivatePowerUp();
        powerUpActive = true;
        powerUpType = "multishot";
        activeUntilTime = Time.time + basicDuration;
    }

    public void ActivateLaser() {
        DeactivatePowerUp();
        powerUpActive = true;
        powerUpType = "laser";
        activeUntilTime = Time.time + basicDuration;
    }

    public void ActivateBerserkAura()
    {
        DeactivatePowerUp();
        powerUpActive = true;
        powerUpType = "berserk";
        activeUntilTime = Time.time + basicDuration;
    }
}
