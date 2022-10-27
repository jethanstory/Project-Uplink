using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameThree : MonoBehaviour
{
   public Transform tm;

    public void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        tm.position = pos;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Infosqueak")
        {
            Object.Destroy(this.gameObject);
            FindObjectOfType<InfosqueakScr>().progressNum++;
        }
    }
}
