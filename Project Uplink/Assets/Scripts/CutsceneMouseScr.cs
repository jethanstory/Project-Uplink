using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneMouseScr : MonoBehaviour
{
    public Transform tm;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Sprite initialSprite;
    public Sprite infoSprite;
    public int endingNum;
    public int cutsceneNum = 0;
    public float speed;
    public bool isTimed = false;
    public float timer;
    private float counter = 0;
    public GameObject target;
    private GameObject currTarget;
    public bool goToPosition;
    private bool getDirection = true;
    private Vector2 direction;
    public GameObject blackScreen;
    public GameObject infosqueakImage;
    private GameObject currInfoImage;

    public void Start()
    {
        tm.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
    }

    public void FixedUpdate()
    {
        switch(endingNum)
        {
            case 0:
                //drag box ending

                switch(cutsceneNum)
                {
                    case 0:
                        //go to infosqueak

                        goToPosition = true;
                        infosqueakImage.GetComponent<SpriteRenderer>().enabled = true;

                        if (currTarget == null)
                        {
                            currTarget = Instantiate(target, new Vector3(6.14f, -3.29f, 0), Quaternion.identity);
                            currTarget.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                            direction = new Vector2(currTarget.transform.position.x - tm.position.x, currTarget.transform.position.y - tm.position.y);
                            currInfoImage = Instantiate(infosqueakImage, new Vector3(6, -3, 0), Quaternion.identity);
                            currInfoImage.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                        }

                        rb.velocity = direction * speed * Time.deltaTime;
                        break;
                    case 1:
                        //stop for a bit

                        //timer go!
                        isTimed = true;
                        timer = 120;

                        //stop moving
                        rb.velocity = Vector2.zero;

                        break;
                    case 2:
                        //drag infosqueak to drag box

                        sr.sprite = infoSprite;
                        Destroy(currInfoImage);

                        goToPosition = true;

                        if (currTarget == null)
                        {
                            currTarget = Instantiate(target, new Vector3(-5f, 0, 0), Quaternion.identity);
                            currTarget.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                            direction = new Vector2(currTarget.transform.position.x - tm.position.x, currTarget.transform.position.y - tm.position.y);
                        }

                        rb.velocity = direction * speed * Time.deltaTime;
                        break;
                    case 3:
                        //wait for a bit

                        //timer go!
                        isTimed = true;
                        timer = 120;

                        //stop moving
                        rb.velocity = Vector2.zero;

                        break;
                    case 4:
                        //go to upload button

                        sr.sprite = initialSprite;
                        GameObject.FindGameObjectWithTag("FileContainer").GetComponent<Text>().text = "Infosqueak.exe";

                        goToPosition = true;

                        if (currTarget == null)
                        {
                            currTarget = Instantiate(target, new Vector3(-5, -3.5f, 0), Quaternion.identity);
                            currTarget.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
                            direction = new Vector2(currTarget.transform.position.x - tm.position.x, currTarget.transform.position.y - tm.position.y);
                        }

                        rb.velocity = direction * speed * Time.deltaTime;

                        break;
                    case 5:
                        //wait a bit more

                        //timer go!
                        isTimed = true;
                        timer = 120;

                        //stop moving
                        rb.velocity = Vector2.zero;

                        break;
                    case 6:
                        //the end
                        GameObject screen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
                        screen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                        FindObjectOfType<EndingManagerScr>().StartRollCredits();
                        Destroy(this);
                        break;
                }
                break;
        }

        if (isTimed)
        {
            counter += Time.deltaTime;

            if (counter >= (timer * Time.deltaTime))
            {
                cutsceneNum++;
                isTimed = false;
                counter = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (goToPosition)
        {
            cutsceneNum++;
            Destroy(currTarget);
        }
    }
}
