using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// The manager will send the information to the canvas, and will print it out. This 
// will contain the pauses for grammar, and completion of sentences.

// Will also change the color of the text based on a custom markup language.
public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    Stack<string> settings;
    Text text;
    string sentence;

   
   public Color[] colors = 
   {
        Color.red,
        Color.white,
        Color.yellow,
        Color.black,
   };
    void Start()
    {
        GameObject.Find("Image").GetComponent<Image>().enabled = false;
        //this.gameObject.SetActive(false);
        sentences = new Queue<string>();
        settings = new Stack<string>();
        // Find the text object
        text = GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>(); 
    }

    // void setupCanvasForDialogue((string, Queue<string>) dialogueObject)
    public void setupCanvasForDialogue(string sentence)
    {
        this.sentence = sentence;
        StartCoroutine("writeDialogToCanvas");
    }

    IEnumerator writeDialogToCanvas()
    {
        // Clear the text
        text.text = "";
        
        // System to add longer wait times on grammatical symbols
        float waitTime = 0;
        for (int i = 0; i < sentence.Length; i++)
        {
            if(sentence[i] == '<')
            {
               i = applyTextSettings(this.sentence, i);
            }
            switch(sentence[i])
            {
                case ',':
                case ':':
                    waitTime = 0.25f;
                break;
                case '.':
                case ';':
                case '?':
                case '!':
                    waitTime = 0.5f;
                break;
                default:
                    waitTime = 0.05f;
                break;
            }
            
             if(settings.Count > 0)
            {
                switch(settings.Peek())
                {
                    case "red":
                        text.text += "<color=" + colorToHexString(colors[0]) + ">" + sentence[i] + "</color>";
                    break;
                    case "green":
                        text.text += "<color=" + colorToHexString(colors[1]) + ">" + sentence[i] + "</color>";
                    break;
                    case "blue":
                        text.text += "<color=" + colorToHexString(colors[2]) + ">" + sentence[i] + "</color>";
                    break;
                    default:
                        text.text += "<color=" + colorToHexString(colors[3]) + ">" + sentence[i] + "</color>";
                    break;
                }
            }
            else
                text.text += sentence[i];
            // Wait for a time before contiuing
           
            yield return new WaitForSeconds(waitTime);
        } 
    }

    int applyTextSettings(string sentence, int startPosition)
    {
        int endPosition = 0;
        string setting = "";
        bool closing = false;
        

        for(int i = startPosition; i < sentence.Length; i++)
        {
            if(sentence[i] == '/')
            {
                settings.Pop();
                closing = true;
            }
           
            if(sentence[i] == '>')
                break;

            endPosition++;
        }
        if(!closing)
        {
            setting = sentence.Substring(startPosition + 1, endPosition - 1);
            Debug.Log(setting);
            settings.Push(setting);
        }

        //sentence.Remove(startPosition, endPosition);

        // Debug.Log(startPosition);
        // Debug.Log(endPosition);
        // Debug.Log(sentence);

        // Now, apply the settings
       
       // for(int i = )
        return endPosition + startPosition + 1;
    }

     string colorToHexString(Color color)
     {
         Color32 color32 = color;
         return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color32.r, color32.g, color32.b, color32.a);
     }
}
