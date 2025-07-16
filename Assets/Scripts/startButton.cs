using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class startButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
           
    }

    public void OnButtonClicked()
    {
        Debug.Log("Start button clicked!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("1STSCENE");
    }
}
