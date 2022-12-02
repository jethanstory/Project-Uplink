using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameOneScr : MonoBehaviour
{
    public SpriteRenderer sr;
    public Transform tm;
    public Rigidbody2D rb;
    public bool isPicked = false;
    public bool inBattle = false;
    public GameObject safeSquare;
    public bool canMove = false;
    public float speed;
    public float stopPos;
    public GameObject victorySound;

    public void Start()
    {
        sr.color = Color.red;

        stopPos = tm.position.x - 20f;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sr.color = Color.green;
            Invoke("DestroySquare", 1f);
            victorySound.SetActive(false);
            victorySound.SetActive(true);
        }
    }

    public void DestroySquare()
    {
        Destroy(gameObject);

        Vector3 currPos = tm.position;
        currPos.z = 0;

        if (isPicked)
        {
            Instantiate(safeSquare, currPos, Quaternion.identity);
        }
        else if (!inBattle)
        {
            FindObjectOfType<InfosqueakScr>().progressNum++;
        }
    }

    public void Update()
    {
        if (inBattle)
        {
            if (canMove)
            {
                rb.velocity = Vector2.left * speed * Time.deltaTime;

                if (tm.position.x <= stopPos)
                {
                    canMove = false;
                    FindObjectOfType<BossLevelSpawnerScr>().startMassiveAttack = true;
                    FindObjectOfType<CancelButtonScr>().hasStopped = true;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
