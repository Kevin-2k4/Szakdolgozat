using UnityEngine;

public class VolumeInitializer : MonoBehaviour
{
    void Start()
    {
        // 1. Get the AudioSource component on this object (the InGameMusic object).
        AudioSource audioSource = GetComponent<AudioSource>();

        // 2. Check if the global Settings manager exists.
        // NOTE: If you are using the Instance/Singleton pattern, this check is better:
        // if (Settings2D.Instance != null) { ... }

        // Simpler check using PlayerPrefs (if the manager failed to run).
        float savedVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);

        if (audioSource != null)
        {
            // 3. Apply the saved volume directly to this object.
            audioSource.volume = savedVolume;
        }
    }
}