using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings2D : MonoBehaviour
{
    private const string VOLUME_KEY = "SoundVolume";

    [Header("Audio Settings")]
    public Slider soundSlider;

    [Header("Audio Sources (Automatically Found)")]
    private AudioSource[] allAudioSources;

    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 1f);

        if (soundSlider != null)
        {
            soundSlider.value = savedVolume;
        }


        ApplySoundVolume();
    }

    void OnEnable()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        ApplySoundVolume();
    }

    public void ChangeSoundVolume()
    {
        if (soundSlider != null)
        {
            ApplySoundVolume();

            PlayerPrefs.SetFloat(VOLUME_KEY, soundSlider.value);
        }
    }

    private void ApplySoundVolume()
    {
        float currentVolume;

        if (soundSlider != null)
        {
            currentVolume = soundSlider.value;
        }
        else
        {
            currentVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 1f);
        }

        foreach (var source in allAudioSources)
        {
            if (source != null)
                source.volume = currentVolume;
        }
    }
}