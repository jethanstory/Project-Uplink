using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleScr : MonoBehaviour
{
    private Text myText;
    public Transform tm;
    public BoxCollider2D bc;

    //creates the speech bubble
    public void CreateBubble(string textString)
    {
        //gets the text from the canvas
        Transform myCanvas = tm.GetChild(0);
        Transform canvasText = myCanvas.GetChild(0);

        myText = canvasText.GetComponent<Text>();

        myText.text = textString; //sets the text to the string in the parameter
        myText.color = Color.black; //sets the color to black
    }
}
