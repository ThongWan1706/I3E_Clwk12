using Unity.VisualScripting;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    MeshRenderer myMeshRenderer;
    
    [SerializeField]
    Material highlightMat;
    Material originalMat;


    void Start()
    {
        //Get the MeshRenderer component and store it into the variable
        myMeshRenderer = GetComponent<MeshRenderer>();

        //Store the original colour of the coin into the variable
        originalMat = myMeshRenderer.material;
    }

    public void highlight()
    {
        //Change the colour from original color to highlight mat
        myMeshRenderer.material = highlightMat;
    }

    public void Unhighlight()
    {
        //Change the colour from highlight mat to original mat
        myMeshRenderer.material = originalMat;
    }

}
