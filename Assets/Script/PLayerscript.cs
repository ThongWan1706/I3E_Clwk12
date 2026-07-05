using UnityEngine;

public class PLayerscript : MonoBehaviour
{
    private bool canInteract = false;
    private CoinBehavior currentcoin;

    // Check whether the player entered the collision area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            CoinBehavior coin = other.GetComponent<CoinBehavior>();

            canInteract = true;
            currentcoin = coin;
            currentcoin.highlight();


        }
    }

    void OnTriggerExit(Collider other)
    {
        canInteract = false;
        currentcoin.Unhighlight();
    }
}