using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMainMenuScr : MonoBehaviour
{
    public GameObject square;
    private GameObject currSquare;
    private Vector3 squarePos;
    float idleTime;

    public int timeBeforePause = 5;
    int checkIt = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        idleTime += Time.deltaTime;
        if (checkIt > 0) {
            Bounce();
            checkIt -= 1;
        }

        // if (idleTime >= timeBeforePause)
        // {
        //     Bounce();
        //     idleTime = 0;
        // }
        
    }

    private Vector3 RandomVector(float min, float max) 
    {
         var x = Random.Range(min, max);
         var y = Random.Range(min, max);
         var z = Random.Range(min, max);
         return new Vector3(x, y, z);
    }

    void Bounce()
    {
        squarePos = new Vector3(0, 0, 0);
        currSquare = Instantiate(square, squarePos, Quaternion.identity);
        //res fix
        currSquare.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
        currSquare.GetComponent<Rigidbody2D>().velocity = RandomVector(-10f, 10f);

    }
}
