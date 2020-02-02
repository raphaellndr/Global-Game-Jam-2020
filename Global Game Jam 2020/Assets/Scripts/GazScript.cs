using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazScript : MonoBehaviour
{
    PlayerController playerController;
    GameObject player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        CancelInvoke("Healing");
        player = collider.gameObject;
        if (collider.gameObject.tag == "Player")
        {
            playerController = collider.GetComponent<PlayerController>();            
            InvokeRepeating("Suffocate", 1, 1);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        CancelInvoke("Suffocate");

        if (collider.gameObject.tag == "Player")
        {
            InvokeRepeating("Healing", 1, 1);
        }
    }

    void Suffocate()
    {
        Mathf.Clamp(playerController.health, 0, 100);
        playerController.health -= 20;

        Vector2 newScale = playerController.fullFillAmount.localScale;
        Mathf.Clamp01(newScale.x);
        newScale.x -= playerController.amount / 5;
        playerController.fullFillAmount.localScale = newScale;

        if (playerController.health == 0)
        {
            Debug.Log(playerController.health);

            Destroy(player);
            CancelInvoke("Suffocate");
        }
    }

    void Healing()
    {
        Mathf.Clamp(playerController.health, 0, 100);
        playerController.health += 20;

        Vector2 newScale = playerController.fullFillAmount.localScale;
        Mathf.Clamp01(newScale.x);
        newScale.x += playerController.amount / 5;
        playerController.fullFillAmount.localScale = newScale;

        if (playerController.health == 100)
        {
            Debug.Log(playerController.health);

            CancelInvoke("Healing");
        }
    }

    void Update()
    {
        if (playerController.health >= 100)
        {
            playerController.health = 100;
        }
    }
}
