using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BadSquareManagerScr : MonoBehaviour
{
    public Transform tm;

    public void BeginMoving()
    {
        for (int i = tm.childCount; i > 0; i--)
        {
            tm.GetChild(i - 1).GetComponent<BossLevelCollisionScr>().canMove = true;
        }
    }

    public void RemoveBadSquares()
    {
        for (int i = tm.childCount; i > 0; i--)
        {
            Object.Destroy(tm.GetChild(i - 1).gameObject);
        }
    }
}
