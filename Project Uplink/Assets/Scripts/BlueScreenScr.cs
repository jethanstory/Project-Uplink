using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueScreenScr : MonoBehaviour
{

    void Start()
    {
        Invoke("RestartGame", 10f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Boss_Level");
    }
}
