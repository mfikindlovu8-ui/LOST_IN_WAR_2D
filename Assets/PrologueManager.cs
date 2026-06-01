using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI dialogueText;
    public GameObject startGameButton;

    [Header("Dialogue Content")]
    [TextArea(3, 5)]
    public string[] lines;
    public float typingSpeed = 0.04f;

    [Header("Scene Transition")]
    // Changed this to target your "Level 1" scene exactly
    public string nextSceneName = "Level 1";

    private int index;
    private bool isTyping;

    void Start()
    {
        dialogueText.text = string.Empty;
        // REMOVED: startGameButton.SetActive(false); 
        // The button will now stay ticked and visible in your scene!
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (index >= lines.Length - 1 && !isTyping) return;

            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndPrologue();
        }
    }

    void EndPrologue()
    {
        Debug.Log("Dialogue finished! The Start Game button is already visible.");
        startGameButton.SetActive(true);
    }

    public void LoadMainGame()
    {
        // This will print in your Unity Console to prove your button works!
        Debug.Log("Button successfully clicked! Attempting to load scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}

