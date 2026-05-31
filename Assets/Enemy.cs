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
        dialoguePanel.SetActive(false);
        contButton.SetActive(false);
    }

    IEnumerator Typing()
    {
        dialogueText.text = "";

        foreach (char letter in dialogue[index])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        contButton.SetActive(true);
    }

    public void NextLine()
    {
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

        dialogueText.text = "";
        index = 0;
        dialogueStarted = false;

        dialoguePanel.SetActive(false);
        contButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogueStarted)
        {
            dialogueStarted = true;

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