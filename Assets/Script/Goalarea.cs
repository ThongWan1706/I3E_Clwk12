using UnityEngine;

public class GoalArea : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1; 
    private bool isBallInside = false; 

    private void OnTriggerEnter(Collider other)
    {
        // Only score if it's the ball and we haven't already registered it
        if (other.CompareTag("Ball") && !isBallInside)
        {
            isBallInside = true; 

            PlayerScript player = FindFirstObjectByType<PlayerScript>();
            if (player != null)
            {
                player.AddScore(scoreValue);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the flag when the ball completely leaves the zone
        if (other.CompareTag("Ball"))
        {
            isBallInside = false; 
        }
    }
}