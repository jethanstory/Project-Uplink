using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelSpawnerScr : MonoBehaviour
{
    public GameObject badSquare;
    private GameObject currBadSquare;
    private Vector3 badSquarePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        badSquarePos = new Vector3(0, 4.45f, 0);
        currBadSquare = Instantiate(badSquare, badSquarePos, Quaternion.identity);
        currBadSquare.transform.SetParent(GameObject.FindGameObjectWithTag("BadSquareManager").transform, true);
        currBadSquare.transform.localScale = new Vector3(15, 1, 1);
    }
}
