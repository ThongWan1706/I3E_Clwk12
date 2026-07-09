using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float kickForce = 50f; // Force applied to the ball
    [SerializeField] private TextMeshProUGUI scoreText;

    private int playerScore = 0;
    private GiftBox currentGiftBox;
    private GameObject currentBall;
    private bool isInGoalArea = false;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (currentGiftBox != null)
            {
                currentGiftBox.OnInteract();
            }
            else if (currentBall != null)
            {
                Debug.Log("Attempting to kick the ball!");
                Rigidbody rb = currentBall.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Debug.Log("Rigidbody found! Applying force.");
                    rb.AddForce(transform.forward * kickForce);
                }
                else
                {
                    Debug.LogWarning("Near the ball, but the Ball object is missing a Rigidbody component!");
                }
            }
            else
            {
                Debug.Log("Pressed E, but player is not near a GiftBox or a Ball.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player touched something named: " + other.gameObject.name + " with Tag: " + other.tag);

        if (other.CompareTag("GiftBox"))
        {
            Debug.Log("GiftBox Tag matched successfully!");
            currentGiftBox = other.GetComponent<GiftBox>();

            if (currentGiftBox != null)
            {
                Debug.Log("GiftBox script component successfully found!");
                currentGiftBox.HighlightBox(true);
            }
            else
            {
                Debug.LogWarning("Touched a GiftBox tag, but the object is missing the GiftBox.cs script!");
            }
        }
        else if (other.CompareTag("Ball"))
        {
            currentBall = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GiftBox"))
        {
            if (currentGiftBox != null)
            {
                currentGiftBox.HighlightBox(false);
                currentGiftBox = null;
            }
        }
        else if (other.CompareTag("Ball"))
        {
            if (currentBall == other.gameObject)
            {
                currentBall = null;
            }
        }
        else if (other.CompareTag("GoalArea"))
        {
            isInGoalArea = false;
        }
    }

   public void AddScore(int points)
    {
        playerScore += points;
        UpdateScoreUI();
        print("Player entered trigger zone with " + playerScore + " points");
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore;
        }
    }
}