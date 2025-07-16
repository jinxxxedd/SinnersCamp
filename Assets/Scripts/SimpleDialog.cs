using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleDialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;
    public string message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
            dialogText.text = message;
        }
    }
}
