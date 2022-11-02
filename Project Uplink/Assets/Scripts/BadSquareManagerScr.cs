using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSquareManagerScr : MonoBehaviour
{
    public Transform tm;
    public void RemoveBadSquares()
    {
        for (int i = tm.childCount; i > 0; i--)
        {
            Object.Destroy(tm.GetChild(i - 1).gameObject);
        }
    }
}
