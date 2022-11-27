using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoUninstallScr : MonoBehaviour
{
    public Button myButton;
    public GameObject uninstallScreen1;
    public GameObject blackScreen;
    private GameObject currBlackScreen;

    public void StartNeutralEnding()
    {
        FindObjectOfType<PresqueakScr>().cutsceneNum++;

        currBlackScreen = Instantiate(blackScreen, Vector3.zero, Quaternion.identity);
        currBlackScreen.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        Invoke("GoToEnding", 1f);
    }

    public void GoToEnding()
    {
        SceneManager.LoadScene("Dropbox_Ending");
    }
}
