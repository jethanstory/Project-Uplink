using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSquareManagerScr : MonoBehaviour
{
    public Transform tm;
    public int pickSquareNum;

    public void PickSquare()
    {
        pickSquareNum = Random.Range(0, tm.childCount);

        tm.GetChild(pickSquareNum).GetComponent<MiniGameOneScr>().isPicked = true;

        MoveSquares();
    }

    public void MoveSquares()
    {
        for (int i = tm.childCount; i > 0; i--)
        {
            tm.GetChild(i - 1).GetComponent<MiniGameOneScr>().canMove = true;
        }
    }

    public void RemoveRedSquares()
    {
        for (int i = tm.childCount; i > 0; i--)
        {
            Destroy(tm.GetChild(i - 1).gameObject);
        }
        
    }
}
