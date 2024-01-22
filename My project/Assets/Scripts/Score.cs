using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float scoreValue = 0f;
    public float points = 1f;

    void FixedUpdate()
    {
        scoreValue += points * Time.fixedDeltaTime;
        Debug.Log(scoreValue);
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Piece" tag
        if (other.CompareTag("Piece"))
        {
            // Add 100 to the score when a piece is collected
            scoreValue += 100;
            // Optionally, you can destroy the piece or perform other actions
            Destroy(other.gameObject);
        }
    }
}
