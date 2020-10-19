using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = GameObject.Find("Text").GetComponent<DialogueManager>();
    }

    // Serializing list of responses to make this a bit easier for me
    public List<string> greetings = new List<string>();
    public List<string> answers = new List<string>();
    public List<string> smallTalk = new List<string>();
    public List<string> unknownResponses = new List<string>();
    public List<string> farewells = new List<string>();

    public void setupQuestionAnswerDialogue(string room, string item, string suspect)
    {
        int random = Random.Range(0, answers.Count);
        string sentence = answers[random];

        sentence = sentence.Replace("<i>", item);
        sentence = sentence.Replace("<r>", room);

       dialogueManager.setupCanvasForDialogue(sentence);
    }

}
