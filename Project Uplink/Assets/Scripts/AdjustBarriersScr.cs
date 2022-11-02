using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustBarriersScr : MonoBehaviour
{
    public Transform tm;
    void Start()
    {
        tm.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
    }

}
