using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelCollisionScr : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool canMove = false;
    public float speed;

    public void Update()
    {
        if (canMove)
        {
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }
    }
}
