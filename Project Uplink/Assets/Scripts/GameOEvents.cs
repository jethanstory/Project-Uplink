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

    // Load Menu
    public void MenuGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
    // Start the game
    public void StartGame() 
    {
        SceneManager.LoadScene("Intro_Welcome"); //Level_1
    }
    // Loads next scene
    public void nextLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    //Loads Credits scene
    public void creditsLevel()
    {
        
        SceneManager.LoadScene("Credits_Scene");
        
    }
    //Loads HMTL_Main scene
    public void mainBroswerLevel()
    {
        
        SceneManager.LoadScene("HTML_Main");
        
    }
    //Loads HTML_Entertainment
    public void entertainmentLevel()
    {
        
        SceneManager.LoadScene("HTML_Entertainment");
        
    }
    //Loads HTML_News
    public void newsLevel()
    {
        
        SceneManager.LoadScene("HTML_News");
        
    }
    public void sportsLevel()
    {
        
        SceneManager.LoadScene("HTML_Sports");
        
    }
    public void businessLevel()
    {
        
        SceneManager.LoadScene("HTML_Business");
        
    }
    //basic mascot menu trigger for the mascot button
    public void mascotMenuTrigger()
    {
        
        mascotMenu.SetActive(true);
        defaultMascot.SetActive(false);
    }

    //mascot menu trigger exit
    public void mascotMenuTriggerExit()
    {
        //if (mascotMenu.activeSelf) 
        //{
            defaultMascot.SetActive(true);
            mascotMenu.SetActive(false);
        //}
        
        //mascotCanvas.SetActive(true);
    }
    //test system for dialogue
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