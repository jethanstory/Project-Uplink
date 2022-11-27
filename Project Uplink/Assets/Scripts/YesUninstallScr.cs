using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesUninstallScr : MonoBehaviour
{
    public Button myButton;
    public GameObject uninstallScreen1;
    public GameObject uninstallScreen2;
    private GameObject currScreen;

    public void StartUninstall()
    {
        FindObjectOfType<PresqueakScr>().cutsceneNum++;
        FindObjectOfType<PresqueakScr>().cutsceneInProgress = false;
        Vector3 pos = uninstallScreen1.GetComponent<Transform>().position;
        Destroy(uninstallScreen1);
        currScreen = Instantiate(uninstallScreen2, pos, Quaternion.identity);
        currScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);
    }
}
