using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;

    public AudioSource audioSource; // Reference to the AudioSource for sound effects
    public AudioClip backgroundMusic; // Sound effect for shooting

    public bool musicPlaying = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed when loading a new scene

        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(gameObject); // Destroy this object if the scene is 5 or 6
            instance = null;
        }
    }

    
}
