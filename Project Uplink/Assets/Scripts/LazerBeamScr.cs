using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeamScr : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Transform tm;
    public Transform cancelButtonPos;
    public float spawnTimer;
    private float spawnCounter;
    public GameObject lazerBeamBody;
    public Vector3 pos;
    private Vector2 direction;
    public bool checkManager = true;

    public void Start()
    {
        direction = new Vector2(pos.x - tm.position.x, pos.y - tm.position.y);
    }

    public void Update()
    {
        rb.velocity = direction * speed * Time.deltaTime;

        spawnCounter += Time.deltaTime;

        if (spawnCounter >= (spawnTimer * Time.deltaTime))
        {
            GameObject currBeam = Instantiate(lazerBeamBody, tm.position, Quaternion.identity);
            currBeam.transform.SetParent(GameObject.FindGameObjectWithTag("LazerBeamManager").transform, true);
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);

        if (checkManager)
        {
            FindObjectOfType<LazerBeamManagerScr>().RemoveLazerBeam();
        }
    }
}
