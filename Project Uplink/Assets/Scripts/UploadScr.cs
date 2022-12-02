using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UploadScr : MonoBehaviour
{
    public Button myButton;
    public GameObject blackScreen;
    private GameObject currBlackScreen;

    public void BeginEnding()
    {
        currBlackScreen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
        currBlackScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        FindObjectOfType<EndingManagerScr>().StartRollCredits();
    }
}
