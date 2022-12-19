using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Coin collection sound
    public AudioClip collectSound;

    void OnMouseOver()
    {
        // If the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Play the collect sound
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Destroy the coin game object
            Destroy(gameObject);
        }
    }
}

