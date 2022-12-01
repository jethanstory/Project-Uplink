using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MiniGameTwoScr : MonoBehaviour
{
    public Transform tm;
    public Rigidbody2D rb;
    private Vector3 initialPos;
    private bool hitBlackSquare = false;
    private bool overCheese = false;
    public int failedNum;
    public GameObject badMouse;
    public GameObject victorySound;
    public GameObject failSound;

    //bad mouse vars
    public bool grabbed = false;

    public void Start()
    {
        initialPos = tm.position;
    }

    public void OnMouseEnter()
    {
        overCheese = true;
    }

    public void OnMouseDrag()
    {
        if (!hitBlackSquare && overCheese)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            tm.position = pos;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Infosqueak")
        {
            Destroy(gameObject);
            FindObjectOfType<BadSquareManagerScr>().RemoveBadSquares();
            FindObjectOfType<InfosqueakScr>().progressNum++;
            victorySound.SetActive(false);
            victorySound.SetActive(true);
        }
        else if (collision.collider.tag == "BadSquare")
        {
            hitBlackSquare = true;
            //Invoke("AdjustPosition", 0.5f);
            AdjustPosition();
            failSound.SetActive(false);
            failSound.SetActive(true);
        }
    }

    private void AdjustPosition()
    {
        tm.position = initialPos;
        failedNum++;

        if (failedNum >= 3 && FindObjectOfType<InfosqueakScr>().cutsceneNum == 20 && FindObjectOfType<InfosqueakScr>().progressNum == 4)
        {
            FindObjectOfType<InfosqueakScr>().progressNum++;
        }

        overCheese = false;
        hitBlackSquare = false;
        grabbed = false;
    }

    public void Update()
    {
        if (grabbed && !hitBlackSquare)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(badMouse.transform.position);
            pos.z = 0f;
            tm.position = badMouse.transform.position;
        }
    }
}
