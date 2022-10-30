using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectText : MonoBehaviour
{
    [SerializeField] private GameObject excMark;
    [SerializeField, TextArea(4, 6)] private string[] ObjectLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text objectText;
    [SerializeField] private float typingTime;


    //[SerializeField] private float typingTime;

    private bool isPlayerInRange;
    private bool didTextStart;
    private int lineIndex;
    
   


    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            if (!didTextStart)
            {
                StartText();
            }
            else if (objectText.text == ObjectLines[lineIndex])
            {
                NextLineText();
            }
            else
            {
                StopAllCoroutines();
                objectText.text = ObjectLines[lineIndex];
            }
            
        }
    }

    private void StartText()
    {
        didTextStart = true;
        dialoguePanel.SetActive(true);
        excMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextLineText()
    {
        lineIndex++;
        if(lineIndex < ObjectLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didTextStart=false;
            dialoguePanel.SetActive(false);
            excMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        objectText.text = string.Empty;
        int charIndex = 0;
        foreach (char ch in ObjectLines[lineIndex])
        {
            objectText.text += ch;
            charIndex++;
            yield return new WaitForSecondsRealtime(typingTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            excMark.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            excMark.SetActive(false);
            
        }
    }
}
