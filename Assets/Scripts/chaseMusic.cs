using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaseMusic : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource for sound effects
    public AudioClip shootSound; // Sound effect for shooting

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed when loading a new scene
        //audioSource.clip = shootSound; // Assign the shoot sound to the AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6)
        {
            Destroy(gameObject); // Destroy this object if the scene is 5 or 6
        }
    }

    public void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound); // Play the shoot sound effect
        }
    }
}
