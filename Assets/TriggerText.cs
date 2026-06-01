using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerText : MonoBehaviour
{
    public GameObject textObject; // Reference to the Text GameObject

    private static GameObject currentText;
    private bool hasPlayed = false;

    private void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(false); // Ensure the text is initially hidden
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Don't trigger again if it has already played
        if (hasPlayed)
            return;

        // Only allow the Player to trigger this
        if (!other.CompareTag("Player"))
            return;

        hasPlayed = true;

        // Hide any currently active text
        if (currentText != null && currentText != textObject)
        {
            currentText.SetActive(false);
        }

        // Show this trigger's text
        if (textObject != null)
        {
            textObject.SetActive(true);
            currentText = textObject;
            StartCoroutine(HideTextAfterDelay());
        }
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        if (textObject != null)
        {
            textObject.SetActive(false);

            if (currentText == textObject)
            {
                currentText = null;
            }
        }
    }
}