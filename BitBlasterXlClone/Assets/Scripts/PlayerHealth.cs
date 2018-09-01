using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int amountShields;
    public GameObject shipSprite;
    public float invincibleTime;
    public Score score;

    public GameObject[] shieldSprites;

    bool invincible = false;

    // Take damage
    public void TakeDamage() {

        if (!invincible) {
            amountShields--;    

            if (amountShields < 0) {
                // destroy ship
                DestroyShip();
            } else {
                // bling invincible
                StartCoroutine(InvincibleAfterDamage());
            }
        }
    }

	private void FixedUpdate()
	{

        for (int i = 0; i < 5; i++)
        {
            // Check for amount of bomb and set sprites active/inactive
            if (i < amountShields)
            {
                shieldSprites[i].SetActive(true);
            }
            else
            {
                shieldSprites[i].SetActive(false);
            }
        }

	}


	// Destroy ship
    public void DestroyShip() {
        Destroy(gameObject);
        if (score.currentScore > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", score.currentScore);    
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }


	// bling for invincibility
    public IEnumerator InvincibleAfterDamage() {

        invincible = true;
        Debug.Log("Now invincible");

        float invTime = invincibleTime / 8f;

        // Loop bling
        for (int i = 0; i < 4; i++) {
            shipSprite.SetActive(false);
            yield return new WaitForSeconds(invTime);
            shipSprite.SetActive(true);
            yield return new WaitForSeconds(invTime);
        }

        invincible = false;
        Debug.Log("Now not invincible");
    }

}
