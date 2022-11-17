using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject yesButton;
    private Vector3 yesButtonPos;
    public GameObject noButton;
    private Vector3 noButtonPos;
    private GameObject currYesButton;
    private GameObject currNoButton;
    public bool inLoadingScene = false;
    public float loadingNum = 0f;
    public float loadingSpeed;
    public GameObject blackScreen;
    private GameObject currBlackScreen;

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

    //advanced minigame 3 vars
    public GameObject timer;
    private GameObject currTimer;
    private Vector3 timerPos;

    public void Start()
    {
        //makes it so that infodsqueak never dies! (when loading another scene)
        DontDestroyOnLoad(gameObject);
    }
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
                    maxProgressNum = 5;

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
                            case 4:
                                //move Infosqueak bot right
                                tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);
                                sr.flipX = false;

                                //create bad squares
                                badSquarePos = new Vector3(0, 5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(18, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(8.5f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(1, 11, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(0, -5, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(18, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(-5.5f, 0, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(7, 9, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(5, 1.5f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(7, 9, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(1, -1, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(2, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                badSquarePos = new Vector3(0, 1.5f, 0);
                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                currBadSquare.transform.localScale = new Vector3(5, 1, 1);
                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);

                                //create the cheese
                                cheesePos = new Vector3(-1, 3.5f, 0);
                                currCheese = Instantiate(cheese, cheesePos, Quaternion.identity);
                                currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                        }
                    }
                    break;
                case 18:
                    //player stuck

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Hmm that's odd...this test does not appear to be functional. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 19:
                    //Infosqueak tries to find an update

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Let me check for any updates. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 20:
                    //Infosqueak finds the update

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Alright I found an update! All I have to do is reset your computer! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 21:
                    //Infosqueak asks if you want to reset

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Would you like to reset your computer?";

                    //create the buttons
                    yesButtonPos = new Vector3(bubblePos.x - 200f, bubblePos.y - 200f, 0);
                    currYesButton = Instantiate(yesButton, yesButtonPos, Quaternion.identity);
                    currYesButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    noButtonPos = new Vector3(bubblePos.x + 200f, bubblePos.y - 200f, 0);
                    currNoButton = Instantiate(noButton, noButtonPos, Quaternion.identity);
                    currNoButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    break;
                case 22:
                    //black screen

                    //delete all the bad squares and cheese
                    FindObjectOfType<BadSquareManagerScr>().RemoveBadSquares();
                    Destroy(FindObjectOfType<MiniGameTwoScr>().gameObject);

                    //delete the buttons and speech bubble
                    Destroy(currYesButton);
                    Destroy(currNoButton);
                    Destroy(currSpeechBubble);

                    //is in a loading scene
                    inLoadingScene = true;

                    //hide infosqueak
                    sr.enabled = false;

                    //load the black screen
                    currBlackScreen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
                    currBlackScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                    break;
                case 23:
                    //welcome back

                    //show infosqueak
                    sr.enabled = true;

                    //remove black screen
                    Destroy(currBlackScreen);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "We have finished the mouse calibration, huzzah! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 24:
                    //talk about keyboard calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Let's start calibrating your keyboard, huzzah again! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 25:
                    //discuss minigame 3

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Click on the textbox and type out the paragraphs that appear on the screen! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 3;

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 26:
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
                                FindObjectOfType<ParagraphManagerScr>().SetText("The quick brown fox jumped over the lazy dog's back.");

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                currTextBox.GetComponent<TextBoxScr>().isTimed = false;
                                break;
                            case 1:
                                //paragraph
                                paragraphPos = new Vector3(-60, 310, 0);
                                currParagraph = Instantiate(paragraph, paragraphPos, Quaternion.identity);
                                currParagraph.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                FindObjectOfType<ParagraphManagerScr>().SetText("The way to get started is to quit talking and begin doing.");

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                currTextBox.GetComponent<TextBoxScr>().isTimed = false;
                                break;
                            case 2:
                                //paragraph
                                paragraphPos = new Vector3(-60, 310, 0);
                                currParagraph = Instantiate(paragraph, paragraphPos, Quaternion.identity);
                                currParagraph.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                FindObjectOfType<ParagraphManagerScr>().SetText("Your time is limited, so don't waste it living someone else's life. Don't be trapped by dogma, which is living with the results of other people's thinking.");

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                currTextBox.GetComponent<TextBoxScr>().isTimed = false;
                                break;
                        }
                    }

                    break;
                case 27:
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
                case 28:
                    //discuss advanced minigame 3

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Alright, now we are going to improve your typing skills! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 29:
                    //discuss advanced minigame 3

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Type out this paragraph before the time runs out! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 1;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 30:
                    //advanced minigame 3

                    //player is in a minigame
                    miniGameInProgress = true;

                    //check if there is no textbox
                    if (currTextBox == null)
                    {
                        switch (progressNum)
                        {
                            case 0:
                                //timer
                                timerPos = new Vector3(-55, 482, 0);
                                currTimer = Instantiate(timer, timerPos, Quaternion.identity);
                                currTimer.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                                //paragraph
                                paragraphPos = new Vector3(-60, 212, 0);
                                currParagraph = Instantiate(paragraph, paragraphPos, Quaternion.identity);
                                currParagraph.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                FindObjectOfType<ParagraphManagerScr>().SetText("Wilma Rudolph, Helen Keller, Walt Disney, Joan of Arc, Nelson Mandela, and Thomas Edison, to name a few, not only climbed mountains, they exceeded limits and expanded boundaries, setting the tone for those who respect and admire them.");

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                currTextBox.GetComponent<TextBoxScr>().isTimed = true;
                                break;
                        }
                    }
                    break;
                case 31:
                    //congrats beating advanced minigame 3

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Ok now this is epic! \r\n[Press Space to Continue]";

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

        if (inLoadingScene)
        {
            loadingNum += Time.deltaTime;

            if (loadingNum >= (loadingSpeed * Time.deltaTime))
            {
                //player is moving to the next cutscene
                cutsceneNum += 1;
                cutsceneInProgress = false;
                inLoadingScene = false;
                loadingNum = 0;
            }
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