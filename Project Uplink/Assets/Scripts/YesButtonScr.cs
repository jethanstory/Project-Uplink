using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesButtonScr : MonoBehaviour
{
    public Button myButton;

    public void PlayerClickedYes()
    {
        FindObjectOfType<InfosqueakScr>().cutsceneNum++;
        FindObjectOfType<InfosqueakScr>().cutsceneInProgress = false;
    }
}
