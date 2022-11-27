using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCheeseScr : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tm;
    public Vector2 shootDirection;
    private Vector3 targetPos;
    public float speed;

    public void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("CancelButton").transform.position;

        shootDirection = new Vector2(targetPos.x - tm.position.x, targetPos.y - tm.position.y);
    }

    public void Update()
    {
        rb.velocity = shootDirection * speed * Time.deltaTime;
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
