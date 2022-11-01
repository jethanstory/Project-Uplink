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
    public SpriteRenderer sr;
    public bool canSkip = false;
    public int progressNum = 0;
    public int maxProgressNum;
    public bool miniGameInProgress = false;

    //minigame 1 vars
    public GameObject square;
    private GameObject currSquare;
    private Vector3 squarePos;

    //advanced minigame 1 vars
    public GameObject movingSquare;
    private GameObject currMovingSquare;
    private Vector3 movingSquarePos;
    //public GameObject badSquare;

    //minigame 2 vars
    public GameObject cheese;
    private GameObject currCheese;
    private Vector3 cheesePos;

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
                    Vector3 currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    Vector3 bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    string myString = "Hello! My name is Infosqueak, your Personal Computer's Personal Assistant! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);
                    


                    //allows player to skip/continue cutscene
                    canSkip = true; 
                    break;
                case 1:
                    //let's start calibration

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                    

                    //the text
                    myString = "Before we get started, let's calibrate your mouse and keyboard! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 2:
                    //start with the mouse calibration

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Let's start with the mouse (the best one, obviously)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 3:
                    //begin first mouse calibration

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

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
                            //res fix
                            currSquare.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

                        }
                        else if (progressNum == 1)
                        {
                            //top left
                            squarePos = new Vector3(-5, 3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                            //res fix
                            currSquare.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                        else if (progressNum == 2)
                        {
                            //top right
                            squarePos = new Vector3(5, 3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                            //res fix
                            currSquare.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                        else if (progressNum == 3)
                        {
                            //bot right
                            squarePos = new Vector3(5, -3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                            //res fix
                            currSquare.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                        else if (progressNum == 4)
                        {
                            //bot left
                            squarePos = new Vector3(-5, -3, 0);
                            currSquare = Instantiate(square, squarePos, Quaternion.identity);
                            //res fix
                            currSquare.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                    }

                    break;
                case 5:
                    //congrats on completing first mini game

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Excellent! We are half way done with the mouse calibration! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 6:
                    //discuss why they are doing the advanced first mini game

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "We here at Uplink want you to be the absolute best before surfing the interwebs! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 7:
                    //instructions for advanced first mini game

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "For this next calibration test, try and click on the square as it moves away from your cursor to up your mouse moving capabilities! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress for next minigame
                    maxProgressNum = 1;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 8:
                    //advanced first mini game part one

                    //player is in a minigame
                    miniGameInProgress = true;

                    //check if a moving square does not exist
                    if (currMovingSquare == null)
                    {
                        if (progressNum == 0)
                        {
                            //center
                            movingSquarePos = new Vector3(0, 0, 0);

                            //create moving square
                            currMovingSquare = Instantiate(movingSquare, movingSquarePos, Quaternion.identity);
                            currMovingSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                    }
                    break;
                case 9:
                    //congrats beating advanced minigame

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Ay lmao (placeholder phrase)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 10:
                    //talk about next minigame

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Now we just need to calibrate the dragging capabilities! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 11:
                    //talk about next minigame

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Click and hold on the cheese and drag it to me (pretty please)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 4;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 12:
                    //cheese dragging minigame
                    miniGameInProgress = true;

                    if (currCheese == null)
                    {
                        //set the cheese position
                        cheesePos = new Vector3(0, 0, 0);
                        if (progressNum == 0)
                        {
                            //move infosqueak bot right
                            tm.position = new Vector3(tm.position.x, tm.position.y, tm.position.z);

                            //create the cheese
                            currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                            //res fix
                            currCheese.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                        else if (progressNum == 1)
                        {
                            //move infosqueak top right
                            tm.position = new Vector3(tm.position.x, tm.position.y * -1, tm.position.z);

                            //create the cheese
                            currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                            //res fix
                            currCheese.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                        else if (progressNum == 2)
                        {
                            //move infosqueak top left

                            //flip
                            sr.flipX = true;

                            tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);

                            //create the cheese
                            currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                            //res fix
                            currCheese.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                        else if (progressNum == 3)
                        {
                            //move infosqueak bot left
                            tm.position = new Vector3(tm.position.x, tm.position.y * -1, tm.position.z);

                            //create the cheese
                            currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                            //res fix
                            currCheese.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }
                    }

                    break;
                case 13:
                    //completed the mouse calibration

                    //reset infosqueak
                    sr.flipX = false;
                    tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);

                    //sets the position of the speech bubble
                    currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
                    bubblePos = Camera.main.WorldToScreenPoint(currPos);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Eureka! We have finished the mouse calibration! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
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
            //currSpeechBubble.transform.SetParent (null);

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
