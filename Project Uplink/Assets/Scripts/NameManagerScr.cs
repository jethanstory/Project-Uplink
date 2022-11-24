using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameManagerScr : MonoBehaviour
{
    public string userName;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SaveName(string text)
    {
        userName = text;
    }
}
