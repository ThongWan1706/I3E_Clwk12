using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    NavMeshAgent myagent;

    [SerializeField]
    Transform targetTransform;

    //Detection radius for the chaser
    [SerializeField] 
    float visionRange = 10f;

    Vector3 originalPosition; //For the chaser to return to its original spot once they cant see the player

    void Awake()
    {
        myagent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        //Save the starting position right when the game begins
        originalPosition = transform.position; 
    }

    void Update()
    {
        if (targetTransform == null) return;
        //Calculate how far away the player is
        float distanceToPlayer = Vector3.Distance(transform.position, targetTransform.position);

        //If player is inside the vision range, start chasing the player
        if (distanceToPlayer <= visionRange)
        {
            myagent.SetDestination(targetTransform.position);
        }

        //If the player exits the vision range, go back home
        else
        {
            myagent.SetDestination(originalPosition);
        }
    }

    //To visually shows the vision range in the Scene view so you can debug easily
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }

}
