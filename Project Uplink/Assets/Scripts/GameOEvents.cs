//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOEvents : MonoBehaviour
{

    public GameObject defaultMascot;
    public GameObject mascotMenu;
    public GameObject mascotDialogue;
    public GameObject mascotQuestion;
    // public int counter = 0;

    // void awake() 
    // {
    //     counter += 1;
    // }
    public void MenuGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

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
    public void mascotMenuTrigger()
    {
        //defaultCanvas.SetActive(false);
        mascotMenu.SetActive(true);
        defaultMascot.SetActive(false);
    }
    public void mascotMenuTriggerExit()
    {
        //if (mascotMenu.activeSelf) 
        //{
            defaultMascot.SetActive(true);
            mascotMenu.SetActive(false);
        //}
        
        //mascotCanvas.SetActive(true);
    }
    public void pickYes()
    {
        //if (mascotMenu.activeSelf) 
        //{
            
            mascotDialogue.SetActive(true);
            mascotQuestion.SetActive(false);
        //}
        
        //mascotCanvas.SetActive(true);
    }
}