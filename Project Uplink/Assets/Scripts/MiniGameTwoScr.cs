using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTwoScr : MonoBehaviour
{
    public Transform tm;
    private Vector3 initialPos;
    private bool hitBlackSquare = false;
    private bool overCheese = false;

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
            Object.Destroy(this.gameObject);
            FindObjectOfType<BadSquareManagerScr>().RemoveBadSquares();
            FindObjectOfType<InfosqueakScr>().progressNum++;
        }
        else if (collision.collider.tag == "BadSquare")
        {
            hitBlackSquare = true;
            Invoke("AdjustPosition", 0.5f);
        }
    }

    private void AdjustPosition()
    {
        tm.position = initialPos;
        overCheese = false;
        hitBlackSquare = false;
    }
}
