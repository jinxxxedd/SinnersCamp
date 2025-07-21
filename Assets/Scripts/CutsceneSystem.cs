using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutsceneSystem : MonoBehaviour
{
    public static CutsceneSystem Instance;

    public GameObject dialoguePanel;
    public Image portraitImage;
    public TMP_Text speakerNameText;
    public TMP_Text dialogueText;

    private DialogueLine[] currentLines;
    private int currentIndex;
    private bool isTyping;

    public bool IsCutsceneActive => dialoguePanel.activeInHierarchy;

    void Awake()
    {
        Instance = this;
        dialoguePanel.SetActive(false);
    }

    public void StartCutscene(DialogueLine[] lines)
    {
        // Prevent starting a new cutscene if one is already active
        if (IsCutsceneActive) return;

        currentLines = lines;
        currentIndex = 0;
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    void Update()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                if (isTyping)
                {
                    StopAllCoroutines();
                    dialogueText.text = currentLines[currentIndex - 1].lineText;
                    isTyping = false;
                }
                else
                {
                    DisplayNextLine();
                }
            }
        }
    }

    void DisplayNextLine()
    {
        if (currentIndex < currentLines.Length)
        {
            DialogueLine line = currentLines[currentIndex];
            speakerNameText.text = line.speakerName;
            portraitImage.sprite = line.portrait;
            StartCoroutine(TypeText(line.lineText));
            currentIndex++;
        }
        else
        {
            EndCutscene();
        }
    }

    IEnumerator TypeText(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }

        isTyping = false;
    }

    void EndCutscene()
    {
        dialoguePanel.SetActive(false);
    }
}
