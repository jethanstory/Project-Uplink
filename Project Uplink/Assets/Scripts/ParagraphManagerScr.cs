using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParagraphManagerScr : MonoBehaviour
{
    public void SetText(string myString)
    {
        GetComponent<Text>().text = myString;
    }

    public void DestroyParagraph()
    {
        Destroy(gameObject);
    }
}
