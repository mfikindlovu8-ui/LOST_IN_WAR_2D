using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;

    private int index = 0;

    public GameObject contButton;
    public float wordSpeed = 0.05f;

    private bool dialogueStarted = false;

    void Start()
    {
        if (dialoguePanel) dialoguePanel.SetActive(false);
        if (contButton) contButton.SetActive(false);
    }

    IEnumerator Typing()
    {
        if (!dialogueText || dialogue.Length == 0) yield break;

        dialogueText.text = "";

        foreach (char letter in dialogue[index])
        {
            if (!dialogueText) yield break;

            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        if (contButton)
            contButton.SetActive(true);
    }

    public void NextLine()
    {
        if (contButton)
            contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            StartCoroutine(Typing());
        }
        else
        {
            CloseDialogue();
        }
    }

    void CloseDialogue()
    {
        StopAllCoroutines();

        if (dialogueText)
            dialogueText.text = "";

        index = 0;
        dialogueStarted = false;

        if (dialoguePanel)
            dialoguePanel.SetActive(false);

        if (contButton)
            contButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogueStarted)
        {
            dialogueStarted = true;

            if (dialoguePanel)
                dialoguePanel.SetActive(true);

            StartCoroutine(Typing());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDialogue();
        }
    }
}