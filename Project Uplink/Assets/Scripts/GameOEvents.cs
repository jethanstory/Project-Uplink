//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOEvents : MonoBehaviour
{

    public GameObject defaultMascot;
    public GameObject mascotMenu;
    public GameObject mascotDialogue;
    public GameObject mascotQuestion;
    public GameObject userText;

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
        
        //SceneManager.LoadScene("HTML_News");
        SceneManager.LoadScene("HTML_404");
        
    }
    public void newsEventsLevel()
    {
        
        SceneManager.LoadScene("HTML_NewsEvents");
        
    }
    public void sportsLevel()
    {
        
        //SceneManager.LoadScene("HTML_Sports");
        SceneManager.LoadScene("HTML_404");
        
    }
    public void sportsInfoLevel()
    {
        
        SceneManager.LoadScene("HTML_SportsInfoPage");
        
    }
    public void sportsLevelFixed()
    {
        
        SceneManager.LoadScene("HTML_Sports");
        
    }
    public void businessLevel()
    {
        
        //SceneManager.LoadScene("HTML_Business");
        SceneManager.LoadScene("HTML_404");
        
    }
    public void businessLevelFixed()
    {
        
        SceneManager.LoadScene("HTML_Business");
        //SceneManager.LoadScene("HTML_404");
        
    }
    public void businessLevel2()
    {
        
        //SceneManager.LoadScene("HTML_Business");
        SceneManager.LoadScene("HTML_BusinessPage2");
        
    }
    public void financeLevel()
    {
        
        SceneManager.LoadScene("HTML_Finance");
        //SceneManager.LoadScene("HTML_404");
        
    }
    public void artsLevel()
    {
        
        //SceneManager.LoadScene("HTML_Arts");
        SceneManager.LoadScene("HTML_404");
        
    }
    public void artEventsLevel()
    {
        
        SceneManager.LoadScene("HTML_ArtEvents");
        
    }
    public void artsLevelFixed()
    {
        
        SceneManager.LoadScene("HTML_Arts");
        
    }
    public void healthLevel()
    {
        
        //SceneManager.LoadScene("HTML_Health");
        SceneManager.LoadScene("HTML_404");
        
    }
    public void healthLevelFixed()
    {
        
        SceneManager.LoadScene("HTML_Health");
        
    }
    public void sciTechLevel()
    {
        
        //SceneManager.LoadScene("HTML_ScienceTechnology");
        SceneManager.LoadScene("HTML_404");
        
    }
    public void sciTechLevelFixed()
    {
        
        SceneManager.LoadScene("HTML_ScienceTechnology");
        
    }
    public void squeakyCleanLevel()
    {
        
        SceneManager.LoadScene("HTML_404");
        
    }
    public void decoyLevel()
    {
        
        SceneManager.LoadScene("HTML_404");
        
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

    public void SendName()
    {
        FindObjectOfType<NameManagerScr>().SaveName(userText.GetComponent<Text>().text);
    }
}