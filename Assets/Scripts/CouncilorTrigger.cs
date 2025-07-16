using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouncilorTrigger : MonoBehaviour
{
    public GameObject monster;
    public GameObject dialogUI;
    public string dialogText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogUI.SetActive(true);
            dialogUI.GetComponentInChildren<UnityEngine.UI.Text>().text = dialogText;

            monster.SetActive(true); // Let the chase begin
        }
    }
}
