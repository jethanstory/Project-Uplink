//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOEvents : MonoBehaviour
{
    // public int counter = 0;

    // void awake() 
    // {
    //     counter += 1;
    // }
    // Start is called before the first frame update
    public void MenuGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Intro_Welcome"); //Level_1
    }
    public void nextLevel()
    {
        //SceneManager.LoadScene("3DLevel_2"); //Level_2 //3DLevel_2
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //if (counter)
    }
}