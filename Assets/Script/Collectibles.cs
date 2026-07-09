using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //Make it public as the week4Practical Script need to have this number
    public int score = 1;

    AudioSource collectibleAudio; //Assign the audio variable

    [SerializeField] //Make it public
    AudioClip collectibleAudioClip; //For Solution 2

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>(); //Get the audio source in Unity
    }

    public void Collect()
    {
        if (collectibleAudio != null)
        {
            collectibleAudio.Play(); //Will play when the object is
        }

        //Solution 1
        //Code: Destroy(gameObject, collectibleAudio.clip.length); 
        //Destroy the object but wait, but it has a short delay after interacting it

        //Solution 2
        AudioSource.PlayClipAtPoint(collectibleAudioClip, transform.position);
        Destroy(gameObject);
        //Unity play with the clip at the position the item is
    }
}
