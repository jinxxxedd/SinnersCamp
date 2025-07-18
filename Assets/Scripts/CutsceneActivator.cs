using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneActivator : MonoBehaviour
{
    [Header("Cutscene Dialogue Lines")]
    public DialogueLine[] lines;

    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (lines != null && lines.Length > 0)
            {
                CutsceneSystem.Instance.StartCutscene(lines);
            }
            else
            {
                Debug.LogWarning("No dialogue lines set in CutsceneActivator.");
            }
        }
    }

}
