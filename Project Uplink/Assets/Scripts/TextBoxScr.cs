using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxScr : MonoBehaviour
{
    public GameObject myParagraph;
    public Text myParagraphText;
    public Text myText;
    public char[] myChars;
    public int correctNum = 0;
    public int maxNum;
    public int posWrong = -1;
    public InputField myInputField;

    public void Start()
    {
        //get the text of the paragraph
        myParagraphText = myParagraph.GetComponent<Text>();

        //get the input field
        myInputField = GetComponent<InputField>();

        //set the chars array
        myChars = new char[myParagraphText.text.Length];

        //get the max number of chars in the paragraph
        maxNum = myParagraphText.text.Length;

        //get the text in the textbox
        myText = transform.GetChild(1).GetComponent<Text>();

        //adds the chars from the paragraph to the chars array
        GetLetters();
    }

    public void Update()
    {
        //check if the player has pressed a key
        if (Input.anyKey)
        {
            //set this text to equal the text in its current state
            myText = transform.GetChild(transform.childCount - 1).GetComponent<Text>();

            //check all the chars to see if its right
            CheckLetters();
        }

        //check if the first wrong char has been deleted
        if (posWrong > myText.text.Length)
        {
            posWrong = -1;
        }

        //checks if the paragraph is complete
        if (correctNum >= maxNum)
        {
            FindObjectOfType<InfosqueakScr>().progressNum++;
            FindObjectOfType<ParagraphScr>().DestroyParagraph();
            Destroy(gameObject);
        }
    }

    private void GetLetters()
    {
        //takes chars from paragraph and puts it into the chars array
        for (int i = 0; i < myParagraphText.text.Length; i++)
        {
            char currChar = myParagraphText.text[i];
            myChars[i] = currChar;
        }
    }

    private void CheckLetters()
    {
        //checks for any incorrect chars
        for (int i = 0; i < myText.text.Length; i++)
        {
            char currChar = myText.text[i];

            //checks if the current char is incorrect
            if (currChar != myChars[i])
            {
                //sets the first position of the incorrect char to equal the position of the current char
                if (posWrong == -1)
                {
                    posWrong = i;
                }
                //sets the textbox to red to indicate that it is wrong
                myInputField.image.color = Color.red;
                //exits out of the method
                return;
            }
        }
        //every letter is currently correct
        //set the number of correct chars to equal the current length of the text in the textbox
        correctNum = myText.text.Length;
        //sets the textbox to white to indicate that it is correct
        myInputField.image.color = Color.white;
    }
}
