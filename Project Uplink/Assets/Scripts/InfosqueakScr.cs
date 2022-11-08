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
    private Vector3 currPos;
    private Vector3 bubblePos;

    //minigame 1 vars
    public GameObject square;
    private GameObject currSquare;
    private Vector3 squarePos;

    //advanced minigame 1 vars
    public GameObject movingSquare;
    private GameObject currMovingSquare;
    private Vector3 movingSquarePos;
    public GameObject badSquare;
    private GameObject currBadSquare;
    private Vector3 badSquarePos;

    //minigame 2 vars
    public GameObject cheese;
    private GameObject currCheese;
    private Vector3 cheesePos;

    //minigame 3 vars
    public GameObject textBox;
    private GameObject currTextBox;
    private Vector3 textBoxPos;
    public GameObject paragraph;
    private GameObject currParagraph;
    private Vector3 paragraphPos;

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
                    ChangedPosition();

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    string myString = "Hello! My name is Infosqueak, your Personal Computer's Personal Assistant! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);



                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 1:
                    //let's start calibration


                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Before we get started, let's calibrate your mouse and keyboard! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 2:
                    //start with the mouse calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Let's start with the mouse (the best one, obviously)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 3:
                    //begin first mouse calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

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
                        switch(progressNum)
                        {
                            case 0:
                                //center square
                                squarePos = new Vector3(0, 0, 0);
                                currSquare = Instantiate(square, squarePos, Quaternion.identity);
                                //res fix
                                currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 1:
                                //top left
                                squarePos = new Vector3(-5, 3, 0);
                                currSquare = Instantiate(square, squarePos, Quaternion.identity);
                                //res fix
                                currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 2:
                                //top right
                                squarePos = new Vector3(5, 3, 0);
                                currSquare = Instantiate(square, squarePos, Quaternion.identity);
                                //movement of square
                                currSquare.GetComponent<Rigidbody2D>().velocity = RandomVector(-5f, 5f);
                                //res fix
                                currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 3:
                                //bot right
                                squarePos = new Vector3(5, -3, 0);
                                currSquare = Instantiate(square, squarePos, Quaternion.identity);
                                //movement of square
                                currSquare.GetComponent<Rigidbody2D>().velocity = RandomVector(-5f, 5f);
                                //res fix
                                currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 4:
                                //bot left
                                squarePos = new Vector3(-5, -3, 0);
                                currSquare = Instantiate(square, squarePos, Quaternion.identity);
                                //movement of square
                                currSquare.GetComponent<Rigidbody2D>().velocity = RandomVector(-5f, 5f); //.AddForce(spawnPoint.forward * range, ForceMode.Impulse);
                                                                                                         //res fix
                                currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                        }
                    }

                    break;
                case 5:
                    //congrats on completing first mini game

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Excellent! We are half way done with the mouse calibration! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 6:
                    //discuss why they are doing the advanced first mini game

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
                    //congrats beating the first part of the advanced minigame

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Excellent! Now try clicking on the square without the square touching the black squares! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 4;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 10:
                    //advanced minigame one

                    //player is in a minigame
                    miniGameInProgress = true;

                    //check if there is a moving square
                    if (currMovingSquare == null)
                    {
                        switch (progressNum)
                        {
                            case 0:
                                //create bad squares
                                badSquarePos = new Vector3(0, 4.45f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(25, 1, 1);

                                //create moving square
                                movingSquarePos = new Vector3(0, 0, 0);
                                currMovingSquare = Instantiate(movingSquare, movingSquarePos, Quaternion.identity);
                                currMovingSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 1:
                                //create bad squares
                                badSquarePos = new Vector3(0, 4.45f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(25, 1, 1);

                                badSquarePos = new Vector3(-8.4f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(1, 12, 1);

                                //create moving square
                                movingSquarePos = new Vector3(0, 0, 0);
                                currMovingSquare = Instantiate(movingSquare, movingSquarePos, Quaternion.identity);
                                currMovingSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 2:
                                //create bad squares
                                badSquarePos = new Vector3(8.4f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(1, 12, 1);

                                badSquarePos = new Vector3(-8.4f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(1, 12, 1);

                                //create moving square
                                movingSquarePos = new Vector3(0, 0, 0);
                                currMovingSquare = Instantiate(movingSquare, movingSquarePos, Quaternion.identity);
                                currMovingSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 3:
                                //create bad squares
                                badSquarePos = new Vector3(0, 4.45f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(25, 1, 1);

                                badSquarePos = new Vector3(8.4f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(1, 12, 1);

                                badSquarePos = new Vector3(-8.4f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                currBadSquare.transform.localScale = new Vector3(1, 12, 1);

                                //create moving square
                                movingSquarePos = new Vector3(0, 0, 0);
                                currMovingSquare = Instantiate(movingSquare, movingSquarePos, Quaternion.identity);
                                currMovingSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                        }
                    }

                    break;
                case 11:
                    //congrats on completing advanced first mini game

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Squeaktastic! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 12:
                    //talk about next minigame

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Now we just need to calibrate the dragging capabilities! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 13:
                    //talk about next minigame

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Click and hold on the cheese and drag it to me (pretty please)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 4;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 14:
                    //cheese dragging minigame
                    miniGameInProgress = true;

                    if (currCheese == null)
                    {
                        //set the cheese position
                        cheesePos = new Vector3(0, 0, 0);

                        switch(progressNum)
                        {
                            case 0:
                                //create the cheese
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                //res fix
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 1:
                                //move infosqueak top right
                                tm.position = new Vector3(tm.position.x, tm.position.y * -1, tm.position.z);

                                //create the cheese
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                //res fix
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 2:
                                //flip
                                sr.flipX = true;

                                //move infosqueak top left
                                tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);

                                //create the cheese
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                //res fix
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 3:
                                //move infosqueak bot left
                                tm.position = new Vector3(tm.position.x, tm.position.y * -1, tm.position.z);
                                //tm.GetComponent<Rigidbody2D>().velocity = RandomVector(-5f, 5f);

                                //create the cheese
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                //res fix
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                        }
                    }
                    break;
                case 15:
                    //congrats on completing the drag mini game

                    //reset infosqueak position
                    tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);
                    sr.flipX = false;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Amazing! Now we need to improve your dragging capabilites! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 16:
                    //tutorial for advanced mini game 2

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Drag the cheese to me but don't touch let the cheese touch the black squares! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 4;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 17:
                    //advanced minigame 2

                    //minigame is in progress
                    miniGameInProgress = true;

                    //check if cheese exists
                    if (currCheese == null)
                    {
                        switch(progressNum)
                        {
                            case 0:
                                //create bad squares
                                badSquarePos = new Vector3(-2, -5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(8, 24, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 69);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                

                                badSquarePos = new Vector3(2, 5.5f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(8, 24, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 69);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                

                                //create cheese
                                cheesePos = new Vector3(-8, 4, 0);
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 1:
                                //move Infosqueak top right
                                tm.position = new Vector3(tm.position.x, tm.position.y * -1, tm.position.z);

                                //create bad squares
                                badSquarePos = new Vector3(-1.5f, 1.5f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(15, 7, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);


                                badSquarePos = new Vector3(0, -4.5f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(18, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(8.5f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 10, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                //create cheese
                                cheesePos = new Vector3(-8, -3, 0);
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 2:
                                //move Infosqueak top left
                                tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);
                                sr.flipX = true;

                                //create bad squares
                                badSquarePos = new Vector3(0, -5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(18, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-8.4f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 10, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(8.4f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 10, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(0, 5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(18, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(1, -2, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(14, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-1, 1, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(14, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(5.5f, 3.8f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 1.6f, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(2.5f, 2.2f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 1.6f, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-0.5f, 3.8f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 1.6f, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-3.5f, 2.2f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 2, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                //create cheese
                                cheesePos = new Vector3(6.5f, -3.5f, 0);
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 3:
                                //move Infosqueak bot left
                                tm.position = new Vector3(tm.position.x, tm.position.y * -1, tm.position.z);

                                //create bad squares
                                badSquarePos = new Vector3(0, 5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(18, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-9, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 10, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(0, -5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(18, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(9, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 10, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(2, 2, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(16, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-2, -1, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(16, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                //slanted
                                badSquarePos = new Vector3(6.5f, 5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(4, 2, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(1.5f, 5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-1, 2, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-3.5f, 5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-6, 2, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-3.5f, -1, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(1.5f, -1, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(6, -1, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 2, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(4, -5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(3, 3, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-1, -5f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(3, 3, 1);
                                currBadSquare.transform.eulerAngles = new Vector3(0, 0, 45);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                //create cheese
                                cheesePos = new Vector3(8, 3.5f, 0);
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                        }
                    }
                    break;
                case 18:
                    //player beat advanced minigame 2

                    //set Infosqueaks position
                    tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);
                    sr.flipX = false;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Superb work! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 19:
                    //player has finished mouse calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "We have now finished the mouse calibration, huzzah! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 20:
                    //begin keyboard calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Now, let's begin calibrating your keyboard! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 21:
                    //discuss mini game 3

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Click on the textbox and type out the paragraph! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 1;

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 22:
                    //minigame 3

                    //player is in minigame
                    miniGameInProgress = true;

                    //check if textbox does not exist
                    if (currTextBox == null)
                    {
                        switch (progressNum)
                        {
                            case 0:
                                //paragraph
                                paragraphPos = new Vector3(-60, 310, 0);
                                currParagraph = Instantiate(paragraph, paragraphPos, Quaternion.identity);
                                currParagraph.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                break;
                        }
                    }

                    break;
                case 23:
                    //completed minigame 3

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Totally tubular! \r\n[Press Space to Continue]";

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
            Destroy(currSpeechBubble);
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

    private Vector3 RandomVector(float min, float max) 
    {
         var x = Random.Range(min, max);
         var y = Random.Range(min, max);
         var z = Random.Range(min, max);
         return new Vector3(x, y, z);
     }

    //run when you need Infosqueak to talk and he is at a different position
    private void ChangedPosition()
    {
        //currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
        currPos = new Vector3(tm.position.x - 2f, tm.position.y + 3f, 0f);
        bubblePos = Camera.main.WorldToScreenPoint(currPos);
    }
}