using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelSpawnerScr : MonoBehaviour
{
    public int attackMove = 0;
    public Transform camPos;
    public Rigidbody2D rb;
    public Transform tm;
    public SpriteRenderer sr;
    public bool canRun = true;

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


    void Update()
    {
        switch(attackMove)
        {
            case 0:
                //bad square
                if (canRun)
                {
                    badSquareAmount = Random.Range(10, 12);
                    badSquareXPos = camPos.position.x + 80f;
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
                                currBadSquare.transform.localScale = new Vector3(1, 7, 1);
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

                    attackMove = Random.Range(0, 2);

                    //can run again
                    canRun = true;
                }

                shootCounter += Time.deltaTime;

                if (shootCounter >= (shootTime * Time.deltaTime))
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
                    redSquarePos = new Vector3(camPos.position.x + 80f, 4, 0);
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
                attackMove = Random.Range(0, 2);
                break;
            default:
                attackMove = Random.Range(0, 2);
                break;
        }
    }

    public void ShootCheese()
    {
        Vector3 shootPos = new Vector3(tm.position.x, tm.position.y + 3f, tm.position.z);
        currCheese = Instantiate(cheese, shootPos, Quaternion.identity);
        currCheese.GetComponent<MiniGameTwoScr>().isAttacking = true;
        sr.color = Color.black;
    }
}
