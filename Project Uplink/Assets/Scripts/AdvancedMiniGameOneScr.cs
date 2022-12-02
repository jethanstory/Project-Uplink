using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class AdvancedMiniGameOneScr : MonoBehaviour
{
    public SpriteRenderer sr;
    public float speed;
    public Rigidbody2D rb;
    public Transform tm;
    public bool isCaught = false;
    private Vector3 initialPos;
    public GameObject victorySound;
    public GameObject failSound;

    public void Start()
    {
        sr.color = Color.red;
        initialPos = tm.position;
    }

    public void Update()
    {
        Vector2 direction = Vector2.zero;
        Vector3 calcMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (CheckMouse())
        {
            float squareTop = tm.position.y + 0.5f;
            float squareBot = tm.position.y - 0.5f;

            if ((calcMousePos.x - tm.position.x > 0)
                && (calcMousePos.y < squareTop && calcMousePos.y > squareBot))
            {
                //go left
                direction.x = -1; 
                direction.y = 0;
            }
            else if ((calcMousePos.x - tm.position.x < 0)
                && (calcMousePos.y < squareTop && calcMousePos.y > squareBot))
            {
                //go right
                direction.x = 1;
                direction.y = 0;
            }
            else 
            {
                if (calcMousePos.y - tm.position.y < 0)
                {
                    //go down
                    direction.x = 0;
                    direction.y = 1;
                }
                else
                {
                    //go up
                    direction.x = 0;
                    direction.y = -1;
                }
            }
        }

        if (isCaught)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sr.color = Color.green;
            isCaught = true;
            Invoke("DestroySquare", 1f);
            // victorySound.SetActive(false);
            // victorySound.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BadSquare")
        {
            //move the square back its original position
            tm.position = initialPos;
            failSound.SetActive(false);
            failSound.SetActive(true);
        }
    }

    public void DestroySquare()
    {
        Destroy(gameObject);
        FindObjectOfType<InfosqueakScr>().progressNum++;
        FindObjectOfType<BadSquareManagerScr>().RemoveBadSquares();
    }

    public bool CheckMouse()
    {
        Vector3 calcMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        calcMousePos.z = 0;

        calcMousePos -= tm.position;

        if (calcMousePos.x < 0)
        {
            calcMousePos.x *= -1;
        }

        if (calcMousePos.y < 0)
        {
            calcMousePos.y *= -1;
        }

        //check if mouse is in range
        if (calcMousePos.x < 3 && calcMousePos.y < 3)
        {
            return true;
        }

        return false;
    }
}
