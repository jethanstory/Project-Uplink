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

    public void Update()
    {
        //checks if player is not in the middle of a cutscene
        if (!cutsceneInProgress)
        {
            switch (cutsceneNum)
            {
                case 0:
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
            }
            //cutscene was initiated, thus player is in cutscene
            cutsceneInProgress = true;
        }

        //checks if player wants to skip a skippable cutscene
        if (canSkip && Input.GetKey(KeyCode.Space))
        {
            //destroys the newly created speech bubble
            Object.Destroy(currSpeechBubble);

            //player is moving to the next cutscene
            cutsceneNum++;

            //player is no longer in a cutscene
            cutsceneInProgress = false;

            //player can no longer skip, for now at least
            canSkip = false;
        }
    }


}
