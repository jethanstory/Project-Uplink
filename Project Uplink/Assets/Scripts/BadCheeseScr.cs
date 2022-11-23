using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCheeseScr : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tm;
    public Vector2 shootDirection;
    public float speed;

    public void Start()
    {
        Vector3 currButtonPos = GameObject.FindGameObjectWithTag("CancelButton").transform.position;
        shootDirection = new Vector2(currButtonPos.x - tm.position.x, currButtonPos.y - tm.position.y);
    }

    public void Update()
    {
        rb.velocity = shootDirection * speed * Time.deltaTime;
    }
}
