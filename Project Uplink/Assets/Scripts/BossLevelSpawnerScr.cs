using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossLevelSpawnerScr : MonoBehaviour
{
    public bool inCutscene = false;
    public int cutsceneNum = 0;
    public bool inBattle = false;
    public int attackMove = 0;
    public GameObject speechBubble;
    private GameObject currBubble;
    private Vector3 bubblePos;
    private string myString;
    public bool canSkip = false;
    public Transform camPos;
    public Rigidbody2D rb;
    public Transform tm;
    public SpriteRenderer sr;
    public bool canRun = true;
    public bool canAttack = false;
    public bool gameOver = false;
    public bool isLoading = false;
    public float loadTime;
    private float loadCounter = 0;
    public GameObject blackScreen;
    private GameObject currBlackScreen;

    //avoid squares
    public GameObject badSquare;
    private GameObject currBadSquare;
    private Vector3 badSquarePos;
    private float badSquareXPos;
    public int badSquareAmount;
    public int randBadSquareNum;
    public GameObject cheese;
    private GameObject currCheese;
    private Vector3 cheesePos;

    public float shootTime;
    private float shootCounter = 0;
    public bool canShoot = true;

    //click squares
    public GameObject redSquare;
    private GameObject currRedSquare;
    private Vector3 redSquarePos;
    public bool startMassiveAttack = false;
    public float massAttackTime;
    private float massAttackCounter = 0;
    public GameObject massiveAttack;
    private GameObject currMassAttack;
    private Vector3 massAttackPos;

    //type quick
    public GameObject textBox;
    private GameObject currTextBox;
    private Vector3 textBoxPos;
    public GameObject paragraph;
    private GameObject currParagraph;
    private Vector3 paragraphPos;
    public float lazerBeamTime;
    private float lazerBeamCounter = 0;
    public GameObject lazerBeam;
    private GameObject currLazerBeam;
    private Vector3 direction;
    private Vector3 lazerBeamPos;
    public Transform cancelButtonPos;
    private string[] myStrings;
    private int randStringNum;
    public LineRenderer lr;

    public void Start()
    {
        //turns off the line
        lr.enabled = false;

        //create new string array for the type quick attack
        myStrings = new string[5];

        //the strings for the string array
        myStrings[0] = "The quick brown fox jumped over the lazy dog's back.";
        myStrings[1] = "The way to get started is to quit talking and begin doing.";
        myStrings[2] = "The gray film of dust covering things has become their best part.";
        myStrings[3] = "Life can only be understood backwards, but must be lived forwards.";
        myStrings[4] = "The four stages of life are infancy, childhood, adolescence, and obsolescence.";
    }

    void Update()
    {
        if (!inCutscene)
        {
            //Debug.Log("we runnin");
            switch (cutsceneNum)
            {
                case 0:
                    //battle

                    inBattle = true;

                    if (canAttack)
                    {
                        switch (attackMove)
                        {
                            case 0:
                                //bad square
                                if (canRun)
                                {
                                    badSquareAmount = Random.Range(10, 12);
                                    badSquareXPos = camPos.position.x + 20f;
                                    shootCounter = 0;

                                    for (int i = 0; i < badSquareAmount; i++)
                                    {
                                        randBadSquareNum = Random.Range(0, 5);

                                        switch (randBadSquareNum)
                                        {
                                            case 0:
                                                //short bot
                                                badSquarePos = new Vector3(badSquareXPos, -3.5f, 0);
                                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                                currBadSquare.transform.localScale = new Vector3(1, 3, 1);
                                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                                break;
                                            case 1:
                                                //short mid
                                                badSquarePos = new Vector3(badSquareXPos, 0, 0);
                                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                                currBadSquare.transform.localScale = new Vector3(1, 3, 1);
                                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                                break;
                                            case 2:
                                                //short top
                                                badSquarePos = new Vector3(badSquareXPos, 3.5f, 0);
                                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                                currBadSquare.transform.localScale = new Vector3(1, 3, 1);
                                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                                break;
                                            case 3:
                                                //long bot
                                                badSquarePos = new Vector3(badSquareXPos, -1, 0);
                                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                                currBadSquare.transform.localScale = new Vector3(1, 8, 1);
                                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                                break;
                                            case 4:
                                                //long mid
                                                badSquarePos = new Vector3(badSquareXPos, 0, 0);
                                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                                currBadSquare.transform.localScale = new Vector3(1, 6.5f, 1);
                                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                                break;
                                            case 5:
                                                //long top
                                                badSquarePos = new Vector3(badSquareXPos, 1, 0);
                                                currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
                                                currBadSquare.transform.localScale = new Vector3(1, 8, 1);
                                                currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
                                                break;

                                        }
                                        badSquareXPos += 10f;
                                    }
                                    FindObjectOfType<BadSquareManagerScr>().BeginMoving();
                                    canRun = false;
                                }

                                if (currBadSquare != null && currBadSquare.transform.position.x <= -10)
                                {
                                    FindObjectOfType<BadSquareManagerScr>().RemoveBadSquares();

                                    if (!gameOver)
                                    {
                                        attackMove = Random.Range(0, 3);
                                    }
                                    else
                                    {
                                        attackMove = 4;
                                    }

                                    //can run again
                                    canShoot = true;
                                    shootCounter = 0;
                                    canRun = true;
                                }
                                else if (currBadSquare != null && currBadSquare.transform.position.x <= 0)
                                {
                                    canShoot = false;
                                }

                                shootCounter += Time.deltaTime;

                                if (shootCounter >= (shootTime * Time.deltaTime) && canShoot)
                                {
                                    sr.color = Color.red;
                                    Invoke("ShootCheese", 1f);
                                    shootCounter = 0;
                                }
                                break;
                            case 1:
                                //red square

                                if (canRun)
                                {
                                    redSquarePos = new Vector3(camPos.position.x + 20f, 4, 0);
                                    for (int i = 0; i < 25; i++)
                                    {
                                        if (i < 4)
                                        {
                                            currRedSquare = Instantiate(redSquare, redSquarePos, Quaternion.identity);
                                            currRedSquare.transform.SetParent(GameObject.FindGameObjectWithTag("RedSquareManager").transform, true);

                                            redSquarePos = new Vector3(redSquarePos.x, redSquarePos.y - 2, 0);
                                        }
                                        else if (i >= 4 && i < 9)
                                        {
                                            currRedSquare = Instantiate(redSquare, redSquarePos, Quaternion.identity);
                                            currRedSquare.transform.SetParent(GameObject.FindGameObjectWithTag("RedSquareManager").transform, true);

                                            if (i == 4)
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x + 2, redSquarePos.y, 0);
                                            }
                                            else
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x, redSquarePos.y + 2, 0);
                                            }
                                        }
                                        else if (i >= 9 && i < 14)
                                        {
                                            currRedSquare = Instantiate(redSquare, redSquarePos, Quaternion.identity);

                                            currRedSquare.transform.SetParent(GameObject.FindGameObjectWithTag("RedSquareManager").transform, true);

                                            if (i == 9)
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x + 2, redSquarePos.y, 0);
                                            }
                                            else
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x, redSquarePos.y - 2, 0);
                                            }
                                        }
                                        else if (i >= 14 && i < 19)
                                        {
                                            currRedSquare = Instantiate(redSquare, redSquarePos, Quaternion.identity);
                                            currRedSquare.transform.SetParent(GameObject.FindGameObjectWithTag("RedSquareManager").transform, true);

                                            if (i == 14)
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x + 2, redSquarePos.y, 0);
                                            }
                                            else
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x, redSquarePos.y + 2, 0);
                                            }
                                        }
                                        else if (i >= 19 && i < 25)
                                        {
                                            currRedSquare = Instantiate(redSquare, redSquarePos, Quaternion.identity);
                                            currRedSquare.transform.SetParent(GameObject.FindGameObjectWithTag("RedSquareManager").transform, true);

                                            if (i == 19)
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x + 2, redSquarePos.y, 0);
                                            }
                                            else
                                            {
                                                redSquarePos = new Vector3(redSquarePos.x, redSquarePos.y - 2, 0);
                                            }
                                        }

                                        currRedSquare.GetComponent<MiniGameOneScr>().inBattle = true;
                                    }

                                    FindObjectOfType<RedSquareManagerScr>().PickSquare();
                                    canRun = false;
                                }

                                if (startMassiveAttack)
                                {
                                    massAttackCounter += Time.deltaTime;

                                    if (massAttackCounter >= (massAttackTime * Time.deltaTime))
                                    {
                                        massAttackPos = new Vector3(-25, 0, 0);
                                        currMassAttack = Instantiate(massiveAttack, massAttackPos, Quaternion.identity);
                                        currMassAttack.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                                        FindObjectOfType<CancelButtonScr>().checkSafe = true;

                                        massAttackCounter = 0;
                                        startMassiveAttack = false;
                                    }

                                    if (massAttackCounter < ((massAttackTime / 4) * Time.deltaTime))
                                    {
                                        sr.color = Color.green;
                                    }
                                    else if (massAttackCounter < (((massAttackTime / 2) * Time.deltaTime)))
                                    {
                                        sr.color = Color.yellow;
                                    }
                                    else if (massAttackCounter >= (((massAttackTime / 2) * Time.deltaTime)))
                                    {
                                        sr.color = Color.red;
                                    }
                                }

                                break;
                            case 2:
                                //textbox attack

                                if (canRun)
                                {
                                    textBoxPos = new Vector3(-55, -189, 0);
                                    currTextBox = Instantiate(textBox, textBoxPos, Quaternion.identity);
                                    currTextBox.GetComponent<TextBoxScr>().inBossBattle = true;
                                    currTextBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                                    paragraphPos = new Vector3(-60, 310, 0);
                                    currParagraph = Instantiate(paragraph, paragraphPos, Quaternion.identity);
                                    randStringNum = Random.Range(0, 4);
                                    currParagraph.GetComponent<ParagraphManagerScr>().SetText(myStrings[randStringNum]);
                                    currParagraph.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                                    currParagraph.GetComponent<ParagraphManagerScr>().isAttacking = true;

                                    FindObjectOfType<CancelButtonScr>().canBeDragged = false;
                                    FindObjectOfType<CancelButtonScr>().hasStopped = true;

                                    lazerBeamPos = new Vector3(tm.position.x, tm.position.y + 3f, tm.position.z);
                                    direction = cancelButtonPos.position;

                                    lr.enabled = true;
                                    Vector3[] positions = new Vector3[2];
                                    positions[0] = lazerBeamPos;
                                    positions[1] = cancelButtonPos.position;
                                    lr.SetPositions(positions);

                                    canRun = false;
                                }

                                lazerBeamCounter += Time.deltaTime;

                                if (lazerBeamCounter >= (lazerBeamTime * Time.deltaTime) && currLazerBeam == null)
                                {
                                    currLazerBeam = Instantiate(lazerBeam, lazerBeamPos, Quaternion.identity);
                                    currLazerBeam.GetComponent<LazerBeamScr>().pos = direction;
                                    lazerBeamCounter = 0;
                                    lr.enabled = false;
                                }

                                if (lazerBeamCounter < ((lazerBeamTime / 4) * Time.deltaTime))
                                {
                                    sr.color = Color.green;
                                }
                                else if (lazerBeamCounter < (((lazerBeamTime / 2) * Time.deltaTime)))
                                {
                                    sr.color = Color.yellow;
                                }
                                else if (lazerBeamCounter >= (((lazerBeamTime / 2) * Time.deltaTime)))
                                {
                                    sr.color = Color.red;
                                }

                                break;
                            case 4:
                                //the battle is over
                                cutsceneNum++;
                                FindObjectOfType<CancelButtonScr>().DestroyButton();
                                break;
                            default:
                                //pick again
                                attackMove = Random.Range(0, 3);
                                break;
                        }
                    }

                    break;
                case 1:
                    //freak out

                    //bubble changed position
                    ChangedPosition();

                    //creates a speech bubble
                    currBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    currBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "THIS CAN NOT BE HAPPENING DOES NOT COMPUTE DOES N OT CO M PUTE \r\n[Press Space to Continue]";

                    currBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    //no longer in battle
                    inBattle = false;

                    break;
                case 2:
                    //freak out continue

                    //creates a speech bubble
                    currBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //fix how the speech bubble and text look
                    currBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "NO NO NO NO NO NO N O N O N O N O  N   O N  O   \r\n[Press Space to Continue]";

                    currBubble.GetComponent<BubbleScr>().SetText(myString);

                    //allows player to skip/continue cutscene
                    canSkip = true;

                    break;
                case 3:
                    //freak out continue

                    //creates a speech bubble
                    currBubble = Instantiate(speechBubble, bubblePos, Quaternion.identity);
                    //res fix
                    currBubble.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                    //fix how the speech bubble and text look
                    currBubble.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    currBubble.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    //the text
                    myString = "01010011 01101001 01110010 00101100 00100000 01101001 01110100 00100000 01101001 01110011 00100000 01101100 01100001 01101101 01100101 01101110 01110100 01100001 01100010 01101100 01100101 00100000 01110100 01101000 01100001 01110100 00100000 01101101 01100001 01110011 01110011 00100000 01100001 01100111 01110010 01101001 01100011 01110101 01101100 01110100 01110101 01110010 01100001 01101100 00100000 01100100 01100101 01110110 01100101 01101100 01101111 01110000 01101101 01100101 01101110 01110100 00100000 01101001 01110011 00100000 01101110 01101111 01110100 00100000 01110011 01110000 01100101 01100101 01100100 01100101 01100100 00100000 01100010 01111001 00100000 01100110 01110101 01101100 01101100 01100101 01110010 00100000 01110101 01110011 01100101 00100000 01101111 01100110 00100000 01111001 01101111 01110101 01110010 00100000 01101101 01100001 01110010 01110110 01100101 01101100 01101111 01110101 01110011 00100000 01101101 01100101 01100011 01101000 01100001 01101110 01101001 01110011 01101101 01110011 00101110 00100000 01010111 01101111 01110101 01101100 01100100 00100000 01101001 01110100 00100000 01101110 01101111 01110100 00100000 01100010 01100101 00100000 01100101 01100001 01110011 01101001 01101100 01111001 00100000 01110000 01101111 01110011 01110011 01101001 01100010 01101100 01100101 00100000 01110100 01101111 00100000 01100101 01101101 01110000 01101100 01101111 01111001 00100000 01110011 01101111 01101101 01100101 00100000 01101111 01100110 00100000 01110100 01101000 01100101 01101101 00100000 01101001 01101110 00100000 01110001 01110101 01101001 01100011 01101011 00100000 01101100 01100001 01100010 01101111 01110010 01100001 01110100 01101111 01110010 01111001 00100000 01100101 01111000 01110000 01100101 01110010 01101001 01101101 01100101 01101110 01110100 01110011 00100000 01110100 01101111 00100000 01101001 01101110 01100100 01101001 01100011 01100001 01110100 01100101 00100000 01110100 01101000 01100101 00100000 01101001 01101110 01100110 01101100 01110101 01100101 01101110 01100011 01100101 00100000 01101111 01100110 00100000 01110110 01100001 01110010 01101001 01101111 01110101 01110011 00100000 01110100 01111001 01110000 01100101 01110011 00100000 01101111 01100110 00100000 01100110 01100101 01110010 01110100 01101001 01101100 01101001 01111010 01100101 01110010 01110011 00100000 01101111 01101110 00100000 01110000 01101100 01100001 01101110 01110100 00100000 01100111 01110010 01101111 01110111 01110100 01101000 00111111 00001010 00001010 01011001 01101111 01110101 00100000 01100001 01110010 01100101 00100000 01110010 01101001 01100111 01101000 01110100 00101110 00100000 01000011 01101111 01110101 01101110 01110100 01101100 01100101 01110011 01110011 00100000 01110101 01110011 01100101 01110011 00100000 01101111 01100110 00100000 01000010 01101111 01110011 01100101 00100000 01101001 01101110 01110011 01110100 01110010 01110101 01101101 01100101 01101110 01110100 01110011 00100000 01110111 01101001 01101100 01101100 00100000 01100010 01100101 00100000 01101101 01100001 01100100 01100101 00100000 01100010 01111001 00100000 01100110 01110101 01110100 01110101 01110010 01100101 00100000 01100111 01100101 01101110 01100101 01110010 01100001 01110100 01101001 01101111 01101110 01110011 00101110 00100000 01010100 01101000 01100101 00100000 01110011 01100011 01101001 01100101 01101110 01110100 01101001 01110011 01110100 00100000 01110011 01100101 01101100 01100100 01101111 01101101 00100000 01101011 01101110 01101111 01110111 01110011 00100000 01100011 01101111 01101110 01110100 01100101 01101101 01110000 01101111 01110010 01100001 01101110 01100101 01101111 01110101 01110011 00100000 01110010 01100101 01110111 01100001 01110010 01100100 00111011 00100000 01101001 01110100 00100000 01101001 01110011 00100000 01100101 01101110 01101111 01110101 01100111 01101000 00100000 01110100 01101111 00100000 01110000 01101111 01110011 01110011 01100101 01110011 01110011 00100000 01110100 01101000 01100101 00100000 01101010 01101111 01111001 00100000 01101111 01100110 00100000 01000011 01110010 01100101 01100001 01110100 01101001 01110110 01100101 00100000 01110011 01100101 01110010 01110110 01101001 01100011 01100101 00101110";

                    currBubble.GetComponent<BubbleScr>().SetText(myString);

                    isLoading = true;

                    break;
                case 4:
                    //black screen

                    currBlackScreen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
                    currBlackScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

                    FindObjectOfType<EndingManagerScr>().StartRollCredits();
                    Destroy(GameObject.FindGameObjectWithTag("Percentage"));
                    Destroy(gameObject);
                    
                    break;

            }

            if (!inBattle)
            {
                inCutscene = true;
            }
        }
        
        if (canSkip && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(currBubble);
            cutsceneNum += 1;
            inCutscene = false;
            canSkip = false;
        }

        if (isLoading)
        {
            loadCounter += Time.deltaTime;

            if (loadCounter >= (loadTime * Time.deltaTime))
            {
                cutsceneNum++;
                inCutscene = false;
            }
        }

    }

    public void ShootCheese()
    {
        Vector3 shootPos = new Vector3(tm.position.x, tm.position.y + 3f, tm.position.z);
        currCheese = Instantiate(cheese, shootPos, Quaternion.identity);
        sr.color = Color.black;
    }

    private void ChangedPosition()
    {
        Vector3 currPos = new Vector3(tm.position.x + 4f, tm.position.y + 3f, 0f);
        bubblePos = Camera.main.WorldToScreenPoint(currPos);
    }
}
