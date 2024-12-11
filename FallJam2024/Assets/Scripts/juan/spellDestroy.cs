using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellDestroy : MonoBehaviour
{
    public float limitspell = 5.5f; // Maximum Y position before the spell is destroyed.

    // Update is called once per frame
    void Update()
    {
        // Destroy the spell if it goes above the defined Y position (limitspell).
        if (transform.position.y > limitspell)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision with specific tags.
        if (collision.gameObject.CompareTag("player"))
        {
            // Destroy the player and the spell.
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // Optionally notify the gameOverMenu.
            gameOverMenu gameOver = FindObjectOfType<gameOverMenu>();
            if (gameOver != null)
            {
                gameOver.OnPlayerDestroyed(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("shield2"))
        {
            // Destroy the shield and the spell.
            Destroy(collision.gameObject); // Destroy the shield
            Destroy(gameObject);           // Destroy the spell
            Debug.Log("Shield destroyed!");
        }
        else if (collision.gameObject.CompareTag("Enemy up"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy down"))
        {
            Destroy(gameObject);
        }
    }


}
