using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    // This variable stays true as long as the app is running
    private static bool hasPlayedOnce = false;

    void Awake()
    {
        if (hasPlayedOnce)
        {
            // If we've already been here, delete this new audio object
            Destroy(gameObject);
        }
        else
        {
            // First time here? Mark it as played and keep it
            hasPlayedOnce = true;
            
            // If you want the audio to KEEP playing even when you leave Scene 1:
            // DontDestroyOnLoad(gameObject); 
        }
    }
}