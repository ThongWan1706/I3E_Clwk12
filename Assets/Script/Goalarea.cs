using UnityEngine;

public class GoalArea : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            PlayerScript player = FindFirstObjectByType<PlayerScript>();
            if (player != null)
            {
                player.AddScore(scoreValue);
            }
        }
    }
}