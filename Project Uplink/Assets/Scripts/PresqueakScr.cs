using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PresqueakScr : MonoBehaviour
{
    public int cutsceneNum = 0;
    public bool cutsceneInProgress = false;
    public GameObject speechBubble;
    private GameObject currSpeechBubble;
    public Transform tm;
    public SpriteRenderer sr;
    public bool canSkip = false;
    private Vector3 currPos;
    private Vector3 bubblePos;
    public bool inLoadingScene = false;
    public float loadingNum = 0f;
    public float loadingSpeed;

    //boss battle vars
    public GameObject obsoletesqueak;
    private GameObject currObsoletesqueak;
    private Vector3 obsoletePos;
    public GameObject badSquare;
    private GameObject currBadSquare;
    private Vector3 badSquarePos;
    public GameObject blackScreen;
    private GameObject currScreen;

    public void Update()
    {
        //checks if player is not in the middle of a cutscene
        if (!cutsceneInProgress)
        {
            switch (cutsceneNum)
            {
                case 0:
                    //question

                    //sets the position of the speech bubble
                    ChangedPosition();

                    //hide cursor
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                    //fix how the speech bubble and text look
                    currSpeechBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currSpeechBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    string myString = "What are you doing? \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 1:
                    //u uninstalling me

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                    //fix how the speech bubble and text look
                    currSpeechBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currSpeechBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "Are you trying to uninstall me? \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 2:
                    //I still have use

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                    //fix how the speech bubble and text look
                    currSpeechBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currSpeechBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "I still have use. I still have use. I still have use. \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 3:
                    //Please

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                    //fix how the speech bubble and text look
                    currSpeechBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currSpeechBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "Please \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 4:
                    //player is deciding

                    //show Cursor
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    break;
                case 5:
                    //This can not be happening

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                    //fix how the speech bubble and text look
                    currSpeechBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currSpeechBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "This can not be happening, does not compute does not compute \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 6:
                    //nnotices the cancel button

                    //creates a speech bubble
                    currSpeechBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //adjusts text to the resolution size
                    currSpeechBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                    //fix how the speech bubble and text look
                    currSpeechBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currSpeechBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "Wait, the cancel button, I must get to it \r\n[Press Space to Continue]";

                    currSpeechBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 7:
                    //summoning black squares

                    inLoadingScene = true;
                    //loadingSpeed = 3000;
                    loadingSpeed = 150;

                    if (currScreen == null)
                    {
                        currScreen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
                        currScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    }

                    break;
                case 8:
                    //create obsoletesqueak
                    obsoletePos = new Vector3(-967, -541, 0);
                    currObsoletesqueak = Instantiate(obsoletesqueak, obsoletePos, Quaternion.identity);
                    currObsoletesqueak.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                    //destroy black screen
                    Destroy(currScreen);

                    //create bad squares

                    //top bad square
                    badSquarePos = new Vector3(0, 14.5f, 0); 
                    currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                    currBadSquare.transform.localScale = new Vector3(20, 20, 1);
                    currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //side bad square
                    badSquarePos = new Vector3(-19, 0, 0);
                    currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                    currBadSquare.transform.localScale = new Vector3(20, 40, 1);
                    currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //bot bad square
                    badSquarePos = new Vector3(0, -14.5f, 0);
                    currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                    currBadSquare.transform.localScale = new Vector3(20, 20, 1);
                    currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    Destroy(gameObject);

                    break;
            }

            cutsceneInProgress = true;


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

    //run when you need Infosqueak to talk and he is at a different position
    private void ChangedPosition()
    {
        //currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
        currPos = new Vector3(tm.position.x + 2f, tm.position.y + 3f, 0f);
        bubblePos = Camera.main.WorldToScreenPoint(currPos);
    }
}
