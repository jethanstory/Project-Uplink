using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditorInternal;
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
    public bool isTimed = false;
    private float infoTimer;
    private float infoCounter = 0;

    public GameObject restartScreen;
    private GameObject currRestartScreen;
    public Sprite[] spriteArray;
    public GameObject victorySound;
    

    public float delayTimer; //= 3;
    public float delayTimerEnd;
    public int idleNum = 1;
    Vector3 lastMouseCoordinate = Vector3.zero;
    //Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
    float idleTime;
    float idleNumTime;
    float timeBeforePause = 5f;
    float timeBeforeIdleReset = 0.1f;
    bool disableIdle = false;

    //bad mouse vars
    public GameObject badMouse;
    private GameObject currBadMouse;
    private Vector3 badMousePos;

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

    //�

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
                    string myString = "Hello, " + FindObjectOfType<NameManagerScr>().userName + "! Thank you for downloading Uplink '97. My name is InfoSqueak, your Personal Computer's Personal Assistant! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);



                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 1:
                    //follow my lead

                    ChangeSprite(1);
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "I'm going to help you get familiar with your computer, so sit tight and follow my lead! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 2:
                    //you have these devices right?

                    
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Assuming you've got all the necessary tools, you should have a keyboard and a mouse in front of you. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 3:
                    //what is a keyboard?

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "A keyboard is sort of like a typewriter, and you can use it to interact with your computer using words, numbers, symbols, and shortcuts. Using a word processor, you can write love notes or even a letter of resignation! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 4:
                    //what is a mouse?

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "A mouse is like, well.. Like me! This tool allows you to interact with your computer by moving a cursor and selecting items on your screen. Keep in mind that this isn't a real mouse, so don't feel bad about manhandling it! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 5:
                    //lets start with mouse

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Let's get started with the mouse (the fake one)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 6:
                    //discuss first mouse calibration test

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "For this first calibration test, please left-click the squares that appear on your screen. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //sets the max progress num before minigame
                    maxProgressNum = 5;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 7:
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
                                currSquare.GetComponent<Rigidbody2D>().velocity = RandomVector(-10f, 10f);
                                //res fix
                                currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                            case 4:
                                //bot left
                                squarePos = new Vector3(-5, -3, 0);
                                currSquare = Instantiate(square, squarePos, Quaternion.identity);
                                //movement of square
                                currSquare.GetComponent<Rigidbody2D>().velocity = RandomVector(-15f, 15f); //.AddForce(spawnPoint.forward * range, ForceMode.Impulse);
                                                                                                         //res fix
                                currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                        }
                    }

                    break;
                case 8:
                    //congrats on completing first mini game

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Very good! You've manipulated a mouse before, haven't you? All jokes aside, we are halfway done with the mouse calibration! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    victorySound.SetActive(false);
                    victorySound.SetActive(true);
                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 9:
                    //discuss why they are doing the advanced first mini game

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "We here at Uplink want to get you completely up to snuff before browsing the world wide web, so crack those knuckles, do some desk stretches, and let's keep going! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 10:
                    //instructions for advanced first mini game

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "This next one is going to be a bit tricky. You still need to left-click the squares that appear on your screen, but this time, the squares will move away from your cursor. Get chasing! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress for next minigame
                    maxProgressNum = 1;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 11:
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
                case 12:
                    //congrats beating the first part of the advanced minigame

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Impressive work! The guys who put this together couldn't even do that one! Now, for this next test, try clicking on the squares before they touch the black shapes! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 4;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 13:
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
                case 14:
                    //congrats on completing advanced first mini game

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Squeaktastic! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    victorySound.SetActive(false);
                    victorySound.SetActive(true);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 15:
                    //talk about next minigame

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Another function of your mouse is the ability to click and drag items on your screen. This is a great tool if you need to click and drag items on your screen! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 16:
                    //talk about next minigame

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "All this instruction is hard work, so I'm feeling mighty peckish! Left-click and hold the cheese and drag it to me (pretty please)! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 4;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 17:
                    //cheese dragging minigame
                    miniGameInProgress = true;

                    if (currCheese == null)
                    {
                        //set the cheese position
                        cheesePos = new Vector3(0, 0, 0);

                        //test canvas image
                        //cheesePos = new Vector3(tm.position.x - 500, tm.position.y + 500, 0);

                        

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
                case 18:
                    //congrats on completing the drag mini game

                    //reset infosqueak position
                    tm.position = new Vector3(tm.position.x * -1, tm.position.y, tm.position.z);
                    sr.flipX = false;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Amazing! As you navigate your personal computer, you may come across situations that require a bit more finesse in your dragging skills. Let's get that wrist working! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    victorySound.SetActive(false);
                    victorySound.SetActive(true);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 19:
                    //tutorial for advanced mini game 2

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Left-click and drag the cheese to me but don't let the cheese touch the black borders, or it'll get moldy! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 5;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 20:
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
                                //currCheese.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                break;
                        }
                    }
                    break;
                case 21:
                    //player stuck

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Hmm, this is odd. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 22:
                    //Keep calm and carry on

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "This may be an outdated version of the program. I'm going to check for an update. Keep calm and carry on. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 23:
                    //Infosqueak looks for update
                    sr.enabled = false;
                    isTimed = true;
                    infoTimer = 1000;

                    break;
                case 24:
                    //Infosqueak finds an update

                    sr.enabled = true;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Good news! I found an update and begun downloading it! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 25:
                    //silence

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "... \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 26:
                    //banter

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Can you whistle? I've tried it, but all I can do is squeak. ... So.. how are you enjoying the tutorial so far? Having fun? Yeah, me too.. You know, " + FindObjectOfType<NameManagerScr>().userName + ", you're my favorite person I've instructed. Yeah.. So.. Anyway.. What are you doing Tuesday? Got any plans? \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 27:
                    //Infosqueak asks if you want to reset

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Oh, great! Alright, so, to apply the update, I have to restart your computer. Don't worry, I've saved your progress, so you won't have to go through all that again! Would you like to restart?";

                    //create the buttons
                    yesButtonPos = new Vector3(bubblePos.x - 200f, bubblePos.y - 200f, 0);
                    currYesButton = Instantiate(yesButton, yesButtonPos, Quaternion.identity);
                    currYesButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    noButtonPos = new Vector3(bubblePos.x + 200f, bubblePos.y - 200f, 0);
                    currNoButton = Instantiate(noButton, noButtonPos, Quaternion.identity);
                    currNoButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    break;
                case 28:
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
                    // currBlackScreen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
                    // currBlackScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    currRestartScreen = Instantiate(restartScreen, Vector3.zero, Quaternion.identity);
                    currRestartScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                    break;
                case 29:
                    //welcome back

                    //show infosqueak
                    sr.enabled = true;

                    //remove black screen
                    //Destroy(currBlackScreen);
                    Destroy(currRestartScreen);

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Welcome back, and sorry for the interruption! I thought those guys fixed this thing already. Anyways, let�s crack on! \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 30:
                    //talk about keyboard calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "For this next tutorial, we�re going to work on your typing skills. The keyboard is an important tool for using a computer. As you continue to operate your personal computer, your keyboard is going to be your pathway to input� Well, what I�m saying is that you�ll need to be familiar with the keyboard to� \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 31:
                    //confusion

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Uhm� \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 32:
                    //confusion continued

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Uhh� \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 33:
                    //I forgor

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Well� I seem to have forgotten what I was saying. Something about, uhm� I don�t know� I guess it must not have been important. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 34:
                    //discuss minigame 3

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Let�s just get you started on your next tutorial, then. For this one, you�ll have to type the example sentence as it appears on your screen into the text box. I�m going to sit this one out to try and collect my thoughts, but I�ll check back in once you�ve finished the first round. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 3;

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 35:
                    //minigame 3

                    //infosqueak disappears
                    sr.enabled = false;

                    //player is in minigame
                    miniGameInProgress = true;
                    disableIdle = true;

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
                case 36:
                    //discuss advanced minigame 3

                    //infosqueak reappears
                    sr.enabled = true;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Fantastic. For this next round, you will be timed, so crack those knuckles, do some desk stretches, and let�s keep going! Oh, wait. I said that before, didn�t I? Just pretend I said something upbeat, have fun, so on and so forth. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //set max progress
                    maxProgressNum = 3;

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 37:
                    //advanced minigame 3

                    //infosqueak disappears
                    sr.enabled = false;

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
                                FindObjectOfType<ParagraphManagerScr>().SetText("The gray film of dust covering things has become their best part.");

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                currTextBox.GetComponent<TextBoxScr>().isTimed = true;
                                break;
                            case 1:
                                //timer
                                timerPos = new Vector3(-55, 482, 0);
                                currTimer = Instantiate(timer, timerPos, Quaternion.identity);
                                currTimer.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                                //paragraph
                                paragraphPos = new Vector3(-60, 212, 0);
                                currParagraph = Instantiate(paragraph, paragraphPos, Quaternion.identity);
                                currParagraph.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                FindObjectOfType<ParagraphManagerScr>().SetText("Life can only be understood backwards, but must be lived forwards.");

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                currTextBox.GetComponent<TextBoxScr>().isTimed = true;
                                break;
                            case 2:
                                //timer
                                timerPos = new Vector3(-55, 482, 0);
                                currTimer = Instantiate(timer, timerPos, Quaternion.identity);
                                currTimer.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                                //paragraph
                                paragraphPos = new Vector3(-60, 212, 0);
                                currParagraph = Instantiate(paragraph, paragraphPos, Quaternion.identity);
                                currParagraph.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                FindObjectOfType<ParagraphManagerScr>().SetText("The four stages of life are infancy, childhood, adolescence, and obsolescence.");

                                //textbox
                                textBoxPos = new Vector3(-55, -189, 0);
                                currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                currTextBox.GetComponent<TextBoxScr>().isTimed = true;
                                break;
                        }
                    }
                    break;
                case 38:
                    //congrats beating advanced minigame 3

                    //infosqueak reappears
                    sr.enabled = true;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Good stuff, huh? Excellent work, by the way. Some pretty big words in there. For the final tutorial of this program, we�ll give you a short preview of various things you may expect to see while browsing the worldwide web. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 39:
                    //explain what links are

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "While using a web browser, you�ll come across interactive buttons or text that will take you to different web pages, and these are called hyperlinks (�links� for short). \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 40:
                    //discuss final minigame (html)

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Open each of the following web pages using the blue links, and that will conclude the tutorial. It will all be over then. Over and done with. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 41:
                    //crippling depression

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "We had some fun though, didn�t we? I know I did. Remember that time you had to feed me cheese? Classic. I was kidding then when I said I was hungry. I can�t eat food because I�m just a collection of code and design elements. Just a lowly program mascot made to help you learn how to use a computer. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 42:
                    //What is my purpose?

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "I hope I did a good job. It is my one purpose after all. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 43:
                    //black screen

                    //is in a loading scene
                    inLoadingScene = true;

                    //hide infosqueak
                    sr.enabled = false;

                    //load the black screen
                    currBlackScreen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
                    currBlackScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                    break;
                case 44:
                    //load html section

                    SceneManager.LoadScene("HTML_Main");

                    break;
            }

            
            if (!miniGameInProgress)
            {
                //cutscene was initiated, thus player is in cutscene
                cutsceneInProgress = true;
            }
            else if(miniGameInProgress && disableIdle == false) 
            {
                IdleCheck();
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

        if (isTimed)
        {
            infoCounter += Time.deltaTime;

            if (infoCounter >= (infoTimer * Time.deltaTime))
            {
                //player is moving to the next cutscene
                cutsceneNum += 1;

                //player is no longer in a cutscene
                cutsceneInProgress = false;

                infoCounter = 0;
                isTimed = false;
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
        
        //current working position
        currPos = new Vector3(tm.position.x - 3f, tm.position.y + 4f, 0f);
        bubblePos = Camera.main.WorldToScreenPoint(currPos);

        //test position
        //bubblePos = new Vector3(tm.position.x - 300f, tm.position.y + 300, 0f);
        
        //bubblePos = Camera.main.ScreenToWorldPoint(currPos);
    }
    
    private void IdleCheck()
    {
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
        Debug.Log("MouseDelta");
        Debug.Log(mouseDelta);
        idleTime += Time.deltaTime;
        // Debug.Log("Mouse Position");
        // Debug.Log(Input.mousePosition);
        // Debug.Log("LastCoordinate");
        // Debug.Log(lastMouseCoordinate);
        if (mouseDelta.x == 0 && idleNum == 1) 
        {
            if (idleTime >= timeBeforePause)
            {
            idleNumTime = 0;
            // StartCoroutine(LoadAfterDelay(delayTimer));
            // idleNum += 1;
            // StartCoroutine(DelayEnd(delayTimerEnd));
            //idleNum += 1;
            //delayTimer = 3;

            ChangedPosition();
            int dialogueNum = Random.Range(0,3);

            currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
            //res fix
            currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

            //the text
            string myString;

            if (dialogueNum == 1) 
                myString = "You're taking a while! \r\n";
            else if (dialogueNum == 2)
                myString = "Do you need any help?! \r\n";
            else
                myString = "Chop Chop! We've got the internet to explore!! \r\n";
            currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);
            
            idleNum += 1;

            }

        }
        else if (mouseDelta.x != 0)
        {
            idleTime = 0;
            Object.Destroy(currSpeechBubble);
            idleNumTime += Time.deltaTime;

            if (idleNumTime >= timeBeforeIdleReset)
            {
                idleNum = 1;
            }
            //StartCoroutine(DelayEnd(delayTimerEnd));
        } 
        
        else {
        //     lastMouseCoordinate = Input.mousePosition;
            
        //     //Object.Destroy(currSpeechBubble);
        }
        lastMouseCoordinate = Input.mousePosition;
        //StartCoroutine(DelayEnd(delayTimerEnd));
    }

    void ChangeSprite(int n) 
    { 
        sr.sprite = spriteArray[n]; 
    }

    
}