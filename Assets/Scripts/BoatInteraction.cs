using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoatInteraction : MonoBehaviour
{
    public GameObject dialogUI;
    public GameObject monster;
    public Button yesButton;
    public Button noButton;

    private bool canEscape = false;

    void Start()
    {
        dialogUI.SetActive(false);
        monster.SetActive(false);

        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogUI.SetActive(true);
        }
    }

    void OnYes()
    {
        dialogUI.SetActive(false);
        canEscape = true;
    }

    void OnNo()
    {
        dialogUI.SetActive(false);
        monster.SetActive(true);
    }

    void Update()
    {
        if (canEscape && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.WinGame();
        }
    }
}
