using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class AdvancedMiniGameOneScr : MonoBehaviour
{
    public SpriteRenderer sr;
    public float speed;
    public Rigidbody2D rb;
    public Transform tm;

    public void Start()
    {
        sr.color = Color.red;
    }

    public void Update()
    {
        Vector2 direction = Vector2.zero;
        Vector3 calcMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (CheckMouse())
        {
            if (calcMousePos.x - tm.position.x > 0)
            {
                direction.x = -1;
            }
            else
            {
                direction.x = 1;
            }

            if (calcMousePos.y - tm.position.y > 0)
            {
                direction.y = -1;
            }
            else
            {
                direction.y = 1;
            }
        }

        rb.velocity = direction * speed * Time.deltaTime;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sr.color = Color.green;
            Invoke("DestroySquare", 1f);
        }
    }

    public void DestroySquare()
    {
        Object.Destroy(this.gameObject);
        FindObjectOfType<InfosqueakScr>().progressNum++;
    }

    public bool CheckMouse()
    {
        Vector3 calcMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        calcMousePos.z = 0;

        calcMousePos -= tm.position;

        if ((calcMousePos.x > -1 && calcMousePos.x < 1) || (calcMousePos.y > -1 && calcMousePos.y < 1))
        {
            return true;
        }

        return false;
    }
}
