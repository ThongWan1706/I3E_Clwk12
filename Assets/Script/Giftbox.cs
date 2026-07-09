using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField] private GameObject objToSpawn; // To place the ball
    [SerializeField] private Material highlightMaterial; // Material to apply when highlighted
    
    private Material originalMaterial;
    private Renderer objRenderer;
    private int interactionCount = 0;
    private const int maxInteractions = 3;

    public void OnInteract()
    {
        interactionCount++;

        if (interactionCount >= maxInteractions)
        {
            OpenGiftBox();
        }
    }

    public void OpenGiftBox()
{
    if (objToSpawn != null)
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 0.5f, 0);
        Instantiate(objToSpawn, spawnPosition, transform.rotation);
    }
    
    Destroy(gameObject);
}

    public void HighlightBox(bool isHighlighted)
    {
        if (objRenderer == null || highlightMaterial == null) return;
        
        objRenderer.material = isHighlighted ? highlightMaterial : originalMaterial;
    }
}