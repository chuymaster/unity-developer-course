using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour {

    public ShootingController shooting;
    public PlayerHealth playerHealth;
    public BombController bombController;
    public PowerupController powerupController;

    public int amountAmmo;

    public void Collect(GameObject collectable) {

        Collectable collectableScript = collectable.GetComponent<Collectable>();

        CollectableType collectableType = collectableScript.collectableType;

        switch (collectableType)
        {
            case CollectableType.Ammo:
                shooting.amountAmmo += amountAmmo;
                break;
            case CollectableType.Shield:
                if (playerHealth.amountShields < 5)
                {
                    playerHealth.amountShields++;
                }
                break;
            case CollectableType.Bomb:
                if (bombController.amountBombs < 5)
                {
                    bombController.amountBombs++;
                }
                break;
            case CollectableType.Multishot:
                powerupController.ActivateMultishot();
                break;
            case CollectableType.Laser:
                powerupController.ActivateLaser();
                break;
            case CollectableType.Berserk:
                powerupController.ActivateBerserkAura();
                break;
        }

        Destroy(collectable);
    }
}
