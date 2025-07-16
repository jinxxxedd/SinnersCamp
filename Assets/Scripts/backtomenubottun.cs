using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backtomenubottun : MonoBehaviour
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
        Debug.Log("Back to menu button clicked!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("STARTMENU");
    }
}
