using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CancelButtonScr : MonoBehaviour
{
    public Transform tm;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    private bool overButton = false;
    public bool isSafe = false;
    public bool checkSafe = false;
    public bool isHeld = false;
    public bool hasStopped = true;
    public bool canBeDragged = false;
    public float speed;

    public void OnMouseEnter()
    {
        overButton = true;
    }

    public void OnMouseDrag()
    {
        if (overButton && canBeDragged)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            tm.position = pos;
            isHeld = true;
        }
    }

    public void OnMouseUp()
    {
        isHeld = false;
    }

    public void Update()
    {
        if (checkSafe)
        {
            if (isSafe)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("MassAttack").GetComponent<Collider2D>());
            }
        }

        if (!isHeld && !hasStopped)
        {
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }
        else if (hasStopped)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ObsoleteSqueak" 
            || collision.collider.tag == "BadCheese"
            || collision.collider.tag == "BadSquare")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.collider.tag == "MassAttack" && !isSafe)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.collider.tag == "MassAttack")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }

        if (collision.collider.tag == "LazerBeam")
        {
            FindObjectOfType<LazerBeamScr>().checkManager = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isSafe = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isSafe = false;
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }
}
