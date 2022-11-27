using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCheeseScr : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tm;
    public Vector2 shootDirection;
    private Vector3 targetPos;
    public float speed;
    public GameObject uninstallScreen;
    public GameObject percent;
    private GameObject currPercent;
    public GameObject cancelButton;
    public GameObject errorMessage;
    private GameObject currMessage;
    public GameObject uninstallTarget;
    private GameObject currTarget;

    public void Start()
    {
        currTarget = Instantiate(uninstallTarget, new Vector3(4, 0, 0), Quaternion.identity);

        targetPos = currTarget.transform.position;

        shootDirection = new Vector2(targetPos.x - tm.position.x, targetPos.y - tm.position.y);
    }

    public void Update()
    {
        rb.velocity = shootDirection * speed * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "UninstallTarget")
        {
            Instantiate(cancelButton, new Vector3(8.5f, 0, 0), Quaternion.identity);
            currPercent = Instantiate(percent, new Vector3(0, 406, 0), Quaternion.identity);
            currPercent.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            currMessage = Instantiate(errorMessage, new Vector3(0, 0, 0), Quaternion.identity);
            currMessage.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            Destroy(GameObject.FindGameObjectWithTag("UninstallScreen"));
            Destroy(currTarget);
            Destroy(gameObject);
        }
    }
}

