using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserSearch : MonoBehaviour
{
    private string input;

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
    // Start is called before the first frame update
    void Start()
    {
        
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

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    string myString = "Welcome to the World Wide Web! \r\n[Press Space to Continue]";

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
                    myString = "Hey! I have an idea! Let's have a quick scavenger hunt to prepare you for the internet!  \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 2:
                    //let's start calibration


                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Before we get started, let's quickly go over the rules!  \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;
                case 3:
                    //start with the mouse calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "First off, we've temporaily disabled most website access until you complete the scavenger hunt!  \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;

                case 4:
                    //start with the mouse calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "Oh this is interesting! I was gathering some updated information on internet safety and I found a couple things! \r\n[Press Space to Continue]";

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
                    myString = "I must digest this information. Please allow a Moment.  \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;
                    break;

                    

                case 6:
                    //start with the mouse calibration

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //the text
                    myString = "INTERNAL UPDATE ERROR 9898: Please Standby for program relaunch \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //sets the max progress num before minigame
                    maxProgressNum = 7;

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
        
    }
    
    public void ReadStringInput(string a)
    {
        input = a;
        Debug.Log(input);
    }
    private void ChangedPosition()
    {
        //currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
        currPos = new Vector3(tm.position.x - 2f, tm.position.y + 3f, 0f);
        bubblePos = Camera.main.WorldToScreenPoint(currPos);
    }
}
