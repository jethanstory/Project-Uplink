using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleScr : MonoBehaviour
{
    public Transform tm;
    public BoxCollider2D bc;
    public SpriteRenderer sr;
    private string textString;
    public float timer = 0;
    public bool startAnimation = false;
    private int currCharNum = 0;
    public float textSpeed;

    public void Update()
    {
        //checks if the script has stated the animation
        if (startAnimation)
        {
            timer += Time.deltaTime; //timer increases

            //checks if the timer is over the limit and if there are still characters in the string
            if (timer > (textSpeed * Time.deltaTime) && currCharNum < textString.Length)
            {
                //adds the letter to the text
                UpdateBubble(textString[currCharNum]);

                //adds one to the number of chars in the text
                currCharNum++;

                //sets the timer back to zero
                timer = 0;
            }
            else if (timer > textSpeed && currCharNum >= textString.Length)
            {
                //stops the animation when there are no more characters to add
                startAnimation = false;
            }
        }
    }

    public void SetText(string myString)
    {
        //sets the bubble's text
        textString = myString;

        //text has been set, start the animation
        startAnimation = true;
    }

    public void UpdateBubble(char myChar)
    {
        //updates the bubble with the current char

        //gets the canvas
        Transform myCanvas = tm.GetChild(0);

        //gets the text
        Transform myCanvasText = myCanvas.GetChild(0);

        //sets the text
        Text myText = myCanvasText.GetComponent<Text>();

        //adds the char to the text
        myText.text += myChar.ToString();
    }

}
