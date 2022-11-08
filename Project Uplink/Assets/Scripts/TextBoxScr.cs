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
        myParagraphText = myParagraph.GetComponent<Text>();
        myInputField = GetComponent<InputField>();
        myChars = new char[myParagraphText.text.Length];
        maxNum = myParagraphText.text.Length;
        myText = transform.GetChild(1).GetComponent<Text>();
        GetLetters();
    }

    public void Update()
    {
        if (Input.anyKey)
        {
            myText = transform.GetChild(transform.childCount - 1).GetComponent<Text>();
            CheckLetters();
        }

        if (posWrong > myText.text.Length)
        {
            posWrong = -1;
        }

        if (correctNum >= maxNum)
        {
            FindObjectOfType<InfosqueakScr>().progressNum++;
            FindObjectOfType<ParagraphScr>().DestroyParagraph();
            Destroy(gameObject);
        }
    }

    private void GetLetters()
    {
        for (int i = 0; i < myParagraphText.text.Length; i++)
        {
            char currChar = myParagraphText.text[i];
            myChars[i] = currChar;
        }
    }

    private void CheckLetters()
    {
        for (int i = 0; i < myText.text.Length; i++)
        {
            char currChar = myText.text[i];

            if (currChar != myChars[i])
            {
                if (posWrong == -1)
                {
                    posWrong = i;
                }
                myInputField.image.color = Color.red;
                return;
            }
        }
        correctNum = myText.text.Length;
        myInputField.image.color = Color.white;
    }
}
