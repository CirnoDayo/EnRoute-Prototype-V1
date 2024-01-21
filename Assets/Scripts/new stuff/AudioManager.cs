using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    // Reference to the AudioSource component
    [SerializeField]
    private AudioSource audioSource;

    // Create a singleton pattern to ensure only one instance exists
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject audioManagerObject = new GameObject("AudioManager");
                    instance = audioManagerObject.AddComponent<AudioManager>();
                    // Ensure the AudioSource component is attached
                    instance.audioSource = audioManagerObject.AddComponent<AudioSource>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Prevent this GameObject from being destroyed when scenes change

        // Ensure AudioSource component is available
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }

    // Play a sound effect
    public void PlaySoundEffect(AudioClip clip)
    {
        if (audioSource == null) return;

        audioSource.clip = clip;
        audioSource.Play();
    }
}
