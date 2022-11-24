using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMouseScr : MonoBehaviour
{
    public float speed;
    private bool canMove = true;
    public Transform tm;
    public Rigidbody2D rb;
    public GameObject target;
    private GameObject currTarget;
    private Vector2 direction;
    public int badMouseCutsceneNum;
    private bool canChangePosition = true;
    private int progressNum = 0;
    private bool isTimed = false;
    private float timer;
    private float counter = 0;

    public void Update()
    {
        switch(badMouseCutsceneNum)
        {
            case 0:
                switch(progressNum)
                {
                    case 0:
                        if (canChangePosition)
                        {
                            //go to cheese
                            currTarget = Instantiate(target, GameObject.FindGameObjectWithTag("Cheese").transform.position, Quaternion.identity);
                            direction = new Vector2(currTarget.transform.position.x - tm.position.x, currTarget.transform.position.y - tm.position.y);
                            canChangePosition = false;
                        }
                        break;
                    case 1:
                        if (canChangePosition)
                        {
                            //drag cheese
                            FindObjectOfType<MiniGameTwoScr>().grabbed = true;
                            currTarget = Instantiate(target, new Vector3(0, 1.5f, 0), Quaternion.identity);
                            direction = new Vector2(currTarget.transform.position.x - tm.position.x, currTarget.transform.position.y - tm.position.y);
                            canChangePosition = false;
                        }
                        break;
                    case 2:
                        if (canChangePosition)
                        {
                            //stop moving
                            canMove = false;
                            isTimed = true;
                            timer = 5000;
                            canChangePosition = false;
                        }
                        break;
                    case 3:
                        if (canChangePosition)
                        {
                            //go to cheese
                            canMove = true;
                            currTarget = Instantiate(target, GameObject.FindGameObjectWithTag("Cheese").transform.position, Quaternion.identity);
                            direction = new Vector2(currTarget.transform.position.x - tm.position.x, currTarget.transform.position.y - tm.position.y);
                            canChangePosition = false;
                        }
                        break;
                    case 4:
                        if (canChangePosition)
                        {
                            //drag cheese
                            FindObjectOfType<MiniGameTwoScr>().grabbed = true;
                            currTarget = Instantiate(target, new Vector3(0, 1.5f, 0), Quaternion.identity);
                            direction = new Vector2(currTarget.transform.position.x - tm.position.x, currTarget.transform.position.y - tm.position.y);
                            canChangePosition = false;
                        }
                        break;
                    case 5:
                        if (canChangePosition)
                        {
                            //stop moving
                            canMove = false;
                            isTimed = true;
                            timer = 5000;
                            canChangePosition = false;
                        }
                        break;
                    case 6:
                        //end
                        FindObjectOfType<InfosqueakScr>().cutsceneNum += 1;
                        FindObjectOfType<InfosqueakScr>().cutsceneInProgress = false;
                        Destroy(gameObject);
                        break;
                }
                break;
        }

        if (canMove)
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (isTimed)
        {
            counter += Time.deltaTime;

            if (counter >= (timer * Time.deltaTime))
            {
                progressNum++;
                canChangePosition = true;
                counter = 0;
                isTimed = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        progressNum++;
        canChangePosition = true;
        Destroy(collision.gameObject);
    }
}
