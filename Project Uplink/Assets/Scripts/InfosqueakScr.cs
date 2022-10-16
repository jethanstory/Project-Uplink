using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfosqueakScr : MonoBehaviour
{
    public int cutsceneNum = 0;
    public bool cutsceneInProgress = false;
    public GameObject speechBubble;
    private GameObject currSpeechBubble;
    public Transform tm;
    public bool canSkip = false;
    public int progressNum = 0;
    public int maxProgressNum;
    public bool miniGameInProgress = false;

    //minigame 1 vars
    public GameObject square;
    private GameObject currSquare;
    public Vector3 squarePos;

    public void Update()
    {
        //checks if player is not in the middle of a cutscene
        if (!cutsceneInProgress)
        {
            switch (cutsceneNum)
            {
                case 0:
                    //introduction

                    //sets the position of the speech bubble
                    Vector3 bubblePos = tm.position;
                    bubblePos.x -= 5f;
                    bubblePos.y += 2f;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);

                    //the text
                    string myString = "Hello! My name is Infosqueak, your Personal Computer's Personal Assistant! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);



                    //allows player to skip/continue cutscene
                    canSkip = true; 
                    break;
                case 1:
                    //let's start calibration

                    //sets the position of the speech bubble
                    bubblePos = tm.position;
                    bubblePos.x -= 5f;
                    bubblePos.y += 2f;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);

                    //the text
                    myString = "Before we get started, let's calibrate your mouse and keyboard! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 2:
                    //start with the mouse calibration

                    //sets the position of the speech bubble
                    bubblePos = tm.position;
                    bubblePos.x -= 5f;
                    bubblePos.y += 2f;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);

                    //the text
                    myString = "Let's start with the mouse (the best one, obviously)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 3:
                    //begin first mouse calibration

                    //sets the position of the speech bubble
                    bubblePos = tm.position;
                    bubblePos.x -= 5f;
                    bubblePos.y += 2f;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);

                    //the text
                    myString = "Click on all the squares that appear on screen! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //sets the max progress num before minigame
                    maxProgressNum = 5;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 4:
                    //square clicking minigame
                    miniGameInProgress = true;
                    
                    if (currSquare == null)
                    {
                        if (progressNum == 0)
                        {
                            //center square
                            squarePos = new Vector3(0, 0, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                        }
                        else if (progressNum == 1)
                        {
                            //top left
                            squarePos = new Vector3(-5, 3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                        }
                        else if (progressNum == 2)
                        {
                            //top right
                            squarePos = new Vector3(5, 3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                        }
                        else if (progressNum == 3)
                        {
                            //bot right
                            squarePos = new Vector3(5, -3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                        }
                        else if (progressNum == 4)
                        {
                            //bot left
                            squarePos = new Vector3(-5, -3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                        }
                    }

                    break;

            }

            if (!miniGameInProgress)
            {
                //cutscene was initiated, thus player is in cutscene
                cutsceneInProgress = true;
            }
        }

        //checks if player wants to skip a skippable cutscene
        if (canSkip && Input.GetKeyDown(KeyCode.Space))
        {
            //destroys the newly created speech bubble
            Object.Destroy(currSpeechBubble);

            //player is moving to the next cutscene
            cutsceneNum += 1;

            //player is no longer in a cutscene
            cutsceneInProgress = false;

            //player can no longer skip, for now at least
            canSkip = false;
        }

        if (miniGameInProgress && progressNum >= maxProgressNum)
        {
            cutsceneNum += 1;
            progressNum = 0;
            miniGameInProgress = false;
        }
    }


}
