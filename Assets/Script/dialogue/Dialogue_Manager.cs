using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[System.Serializable]

public class Dialogue_Manager : MonoBehaviour
{
    public Dialogue dialogue;

    //public string name;

    //[TextArea(3, 10)]
    //public string[] sentenceList;

    Queue<string> sentences;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    public float typingSpeed;

    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void StartDialogue()
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentenceList) 
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if (sentences.Count <= 0) 
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence= sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = " ";

        foreach(char letter in sentence.ToCharArray())
        { 
            displayText.text += letter; 
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            dialoguePanel.SetActive(true);
            UI1.SetActive(false);
            UI2.SetActive(false);
            UI3.SetActive(false);
            UI4.SetActive(false);
            StartDialogue();
            //Debug.Log("FUNCIONA");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKeyUp(KeyCode.Return))  //&& displayText.text == activeSentence
            {
                DisplayNextSentence();
            }
            //Debug.Log("FUNCIONA");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            UI1.SetActive(true);
            UI2.SetActive(true);
            UI3.SetActive(true);
            UI4.SetActive(true);
            StopAllCoroutines();
        }
    }
}
