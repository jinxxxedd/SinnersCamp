using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class SimpleDialog : MonoBehaviour
{
    public GameObject dialogPanel;     // The panel that holds the dialog
    public TMP_Text dialogText;        // The actual TMP text component
    public string message;             // The message to show

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);      // Show the dialog panel
            dialogText.text = message;        // Set the text
        }
    }
}