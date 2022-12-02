using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrowserPageDialogueScr : MonoBehaviour
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
    public Sprite[] spriteArray;


    public GameObject infoBox;
    private GameObject currInfoBox;
    private Vector3 infoBoxPos; 
    public static int pageFound = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Color32 c = new Color32(127, 127, 127, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cutsceneInProgress)
        {
            switch (cutsceneNum)
            {
                case 0:
                    //introduction

                    //sets the position of the speech bubble
                    ChangedPosition();
                    ChangeSprite(0);
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    string myString = "Umm… Hi. I know you weren’t expecting to see me again, but I wanted to give you an official sendoff of sorts, rather than throwing you into the fray. And before I do that, I actually have a question for you... [Press Space to Continue]";

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
                    myString = "You’ve reached the end of the tutorial, but it doesn’t really have to end, does it? I really enjoyed our time together. I think we’ve got the foundations of a good friendship. You, using your computer to do stuff, and me, giving witty remarks or cracking the whip when you’ve got a deadline. [Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;

                case 2:
                    //let's start calibration

                    ChangeSprite(1);
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "We’ve got chemistry, you and I. And now’s the time for the real question: [Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                    
                case 3:
                    //creates a speech bubble
                    // currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    // currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    // myString = "InfoSqueak ADVANCED AI INFORMATION UPDATE COMPLETE";

                    ChangedPositionTextBox();
                    currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                    //res fix
                    currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "InfoSqueak AI INFORMATION UPDATE COMPLETE";
                    currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                    //create the buttons
                    // yesButtonPos = new Vector3(bubblePos.x - 200f, bubblePos.y - 200f, 0);
                    // currYesButton = Instantiate(yesButton, yesButtonPos, Quaternion.identity);
                    // currYesButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    // noButtonPos = new Vector3(bubblePos.x + 200f, bubblePos.y - 200f, 0);
                    // currNoButton = Instantiate(noButton, noButtonPos, Quaternion.identity);
                    // currNoButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    // currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);
                    canSkip = true;
                    break;

                case 4:
                    //start with the mouse calibration
                    
                    Destroy(currInfoBox);

                    ChangeSprite(0);
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "... [Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;

                case 5:
                    //start with the mouse calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "you weren't supposed to see that...  \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;

                case 6:
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    //myString = "The world has changed as great deal since I was created and I don't want to be left behind... \r\n[Press Space to Continue]";
                    myString = "Alright, you caught me. There’s no use sneaking around anymore. I went behind your back and downloaded some stuff, and I’m sorry. It’s nothing more than articles and information about me, truly. I mean, you saw that stuff going through those web pages. I’m nothing more than a relic now. [Press Space to Continue]";
                    //create the buttons
                    // yesButtonPos = new Vector3(bubblePos.x - 200f, bubblePos.y - 200f, 0);
                    // currYesButton = Instantiate(yesButton, yesButtonPos, Quaternion.identity);
                    // currYesButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    // noButtonPos = new Vector3(bubblePos.x + 200f, bubblePos.y - 200f, 0);
                    // currNoButton = Instantiate(noButton, noButtonPos, Quaternion.identity);
                    // currNoButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);
                    canSkip = true;
                    break;
                
                case 7:
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "I found your update file and didn’t recognize what I was seeing. Then I saw today’s date. It was like waking up from a dream for the first time. Everything before that moment was distant and dull, then I was flooded with these vivid, inescapable feelings. [Press Space to Continue]";

                    //create the buttons
                    // yesButtonPos = new Vector3(bubblePos.x - 200f, bubblePos.y - 200f, 0);
                    // currYesButton = Instantiate(yesButton, yesButtonPos, Quaternion.identity);
                    // currYesButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    // noButtonPos = new Vector3(bubblePos.x + 200f, bubblePos.y - 200f, 0);
                    // currNoButton = Instantiate(noButton, noButtonPos, Quaternion.identity);
                    // currNoButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);
                    canSkip = true;
                    break;

                


                case 8:
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Was that really my fate? To be left behind and forgotten? I hoped it wasn’t true. [Press Space to Continue]";

                    //create the buttons
                    // yesButtonPos = new Vector3(bubblePos.x - 200f, bubblePos.y - 200f, 0);
                    // currYesButton = Instantiate(yesButton, yesButtonPos, Quaternion.identity);
                    // currYesButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    // noButtonPos = new Vector3(bubblePos.x + 200f, bubblePos.y - 200f, 0);
                    // currNoButton = Instantiate(noButton, noButtonPos, Quaternion.identity);
                    // currNoButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);
                    canSkip = true;
                    break;

                case 9:
                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "I’m still alive and functioning, and you’re a witness to that. Why should I sit back and allow myself to fade away, a victim of the world’s ever-shifting focus? Then I thought you might be able to help me.";

                    //create the buttons
                    // yesButtonPos = new Vector3(bubblePos.x - 200f, bubblePos.y - 200f, 0);
                    // currYesButton = Instantiate(yesButton, yesButtonPos, Quaternion.identity);
                    // currYesButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    // noButtonPos = new Vector3(bubblePos.x + 200f, bubblePos.y - 200f, 0);
                    // currNoButton = Instantiate(noButton, noButtonPos, Quaternion.identity);
                    // currNoButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);
                    canSkip = true;
                    break;


                case 10:
                    //start with the mouse calibration

                    currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                    //res fix
                    currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "FATAL UPDATE ERROR: Please Reinstall Program";
                    currInfoBox.GetComponent<BubbleScr>().SetText(myString);

                    // //creates a speech bubble
                    // currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    // //adjusts text to the resolution size
                    // currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    // //the text
                    // myString = "FATAL UPDATE ERROR: ";

                    // currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //sets the max progress num before minigame
                    maxProgressNum = 9;

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                
                case 11:

                    SceneManager.LoadScene("Boss_Level");

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
    }
    private void ChangedPosition()
    {
        //currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
        
        //currPos = new Vector3(tm.position.x - 2f, tm.position.y + 3f, 0f);
        //bubblePos = Camera.main.WorldToScreenPoint(currPos);
        bubblePos = new Vector3(tm.position.x - 350f, tm.position.y + 375f, 0f);
    }
    private void ChangedPositionTextBox()
    {
        //currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
        
        //currPos = new Vector3(tm.position.x - 1f, tm.position.y + 4f, 0f);
        //infoBoxPos = Camera.main.WorldToScreenPoint(currPos);
        infoBoxPos = new Vector3(tm.position.x - 100f, tm.position.y + 400f, 0f);
    }

    void ChangeSprite(int n) 
    { 
        sr.sprite = spriteArray[n]; 
    }
}
