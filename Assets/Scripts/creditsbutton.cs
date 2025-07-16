using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        // Load the credits scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }
}
