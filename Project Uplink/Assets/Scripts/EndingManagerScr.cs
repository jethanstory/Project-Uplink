using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManagerScr : MonoBehaviour
{
    public int endingNum;
    public GameObject cutsceneMouse;

    public void Start()
    {
        Scene myScene = SceneManager.GetActiveScene();

        if (myScene.name == "Dropbox_Ending")
        {
            //Drag box ending

            //make cursor invisible
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //create cutscene mouse
            GameObject myMouse = Instantiate(cutsceneMouse, Vector3.zero, Quaternion.identity);
            myMouse.GetComponent<CutsceneMouseScr>().endingNum = 0;
        }
    }

    public void StartRollCredits()
    {
        Invoke("RollCredits", 10f);
    }

    private void RollCredits()
    {
        SceneManager.LoadScene("Credits_Scene");

        //cursor can be moved and seen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
