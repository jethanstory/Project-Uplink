using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameOneScr : MonoBehaviour
{
    public SpriteRenderer sr; 

    public void Start()
    {
        sr.color = Color.red;
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
}
