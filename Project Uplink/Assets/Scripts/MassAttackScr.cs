using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassAttackScr : MonoBehaviour
{
    public Transform tm;
    public Rigidbody2D rb;
    public float speed;

    void Update()
    {
        rb.velocity = Vector2.right * speed * Time.deltaTime;

        if (tm.position.x >= 25)
        {
            FindObjectOfType<RedSquareManagerScr>().RemoveRedSquares();
            Destroy(GameObject.FindGameObjectWithTag("SafeSquare"));
            FindObjectOfType<BossLevelSpawnerScr>().canRun = true;
            FindObjectOfType<BossLevelSpawnerScr>().startMassiveAttack = false;
            FindObjectOfType<BossLevelSpawnerScr>().attackMove = Random.Range(0, 3);
            FindObjectOfType<BossLevelSpawnerScr>().sr.color = Color.black;
            FindObjectOfType<CancelButtonScr>().checkSafe = false;
            FindObjectOfType<CancelButtonScr>().hasStopped = false;

            Destroy(gameObject);
        }
    }
}
