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

    //boss battle vars
    public bool isAttacking = false;
    public Vector2 shootDirection;
    public float speed;

    public void Start()
    {
        initialPos = tm.position;

        Vector3 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootDirection = new Vector2(currMousePos.x - tm.position.x, currMousePos.y - tm.position.y);
    }

    public void OnMouseEnter()
    {
        overCheese = true;
    }

    public void OnMouseDrag()
    {
        if (!hitBlackSquare && overCheese && !isAttacking)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            tm.position = pos;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAttacking)
        {
            if (collision.collider.tag == "Infosqueak")
            {
                Destroy(gameObject);
                FindObjectOfType<BadSquareManagerScr>().RemoveBadSquares();
                FindObjectOfType<InfosqueakScr>().progressNum++;
            }
            else if (collision.collider.tag == "BadSquare")
            {
                hitBlackSquare = true;
                Invoke("AdjustPosition", 0.5f);
            }
        }
    }

    private void AdjustPosition()
    {
        tm.position = initialPos;
        failedNum++;

        if (failedNum >= 3 && FindObjectOfType<InfosqueakScr>().progressNum == 4)
        {
            FindObjectOfType<InfosqueakScr>().progressNum++;
        }

        overCheese = false;
        hitBlackSquare = false;
    }

    public void Update()
    {
        if (isAttacking)
        {
            rb.velocity = shootDirection * speed * Time.deltaTime;
        }
    }
}
