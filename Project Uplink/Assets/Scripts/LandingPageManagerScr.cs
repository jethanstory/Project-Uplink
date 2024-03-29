using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LandingPageManagerScr : MonoBehaviour
{
    public GameObject newsText;
    public GameObject sportsText;
    public GameObject financeText;
    public GameObject businessText;
    public GameObject entertainmentText;
    public GameObject sciTechText;
    public GameObject artText;
    public GameObject healthText;
    public GameObject tourPageText;

    private bool artBool;
    private bool techBool;
    private bool entertainmentBool;
    private bool healthBool;
    private bool sportsBool;
    private bool newsBool;
    private bool businessBool;
    private bool financeBool;

    public static int artInt = 1;
    public static int techInt = 1;
    public static int entertainmentInt = 1;
    public static int healthInt = 1;
    public static int sportsInt = 1;
    public static int techSciInt = 1;
    public static int financeInt = 1;
    public static int businessInt = 1;
    public static int newsInt = 1;

    public GameObject infoBox;
    private GameObject currInfoBox;
    private Vector3 infoBoxPos; 
    public static int pageFound = 0;
    public Transform tm;
    private Vector3 currPos;

    public GameObject currCanvas; 

    public int setupInit = 1;

    public GameObject soundBoard;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        
        // if (sceneName != "HTML_Main") 
        // {
            
        // }
        

        //  if (sceneName == "HTML_News" || sceneName == "HTML_Sports" || sceneName == "HTML_Finance" || sceneName == "HTML_Business" || sceneName == "HTML_Health" || sceneName == "HTML_ScienceTechnology" || sceneName == "HTML_Arts" || sceneName == "HTML_Entertainment") 
        //   {
        //     soundBoard.SetActive(true);
            
        //   }
        // if (sceneName == "HTML_News") 
        //  {
        //     // newsText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_Arts")
        //  {
        //     artBool = true;
        //     //  artText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_Business")
        //  {
        //     businessBool = true;
        //     //  businessText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_Finance")
        //  {
        //     financeBool = true;
        //     //  financeText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_ScienceTechnology")
        //  {
        //     techBool = true;
        //     //  sciTechText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_Sports")
        //  {
        //     sportsBool = true;
        //     //  sportsText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_Health")
        //  {
        //     healthBool = true;
        //     //  healthText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_Entertainment")
        //  {
        //     entertainmentBool = true;
        //     //  entertainmentText.GetComponent<Text>().color = Color.red;
        //  }
        //  else if (sceneName == "HTML_Main")
        //  {
        //     if (artBool)
        //         artText.GetComponent<Text>().color = Color.red;

        //     if (sportsBool)
        //         sportsText.GetComponent<Text>().color = Color.red;
            
        //     if (businessBool)
        //         businessText.GetComponent<Text>().color = Color.red;

        //     if (entertainmentBool)
        //         entertainmentText.GetComponent<Text>().color = Color.red;
            
        //     if (financeBool)
        //         financeText.GetComponent<Text>().color = Color.red;

        //     if (techBool)
        //         sciTechText.GetComponent<Text>().color = Color.red;
            
        //     if (newsBool)
        //         newsText.GetComponent<Text>().color = Color.red;
            
        //     if (healthBool)
        //         healthText.GetComponent<Text>().color = Color.red;
        //  }

        if (sceneName == "HTML_Arts")
        {
            if (artInt == 1) {

                soundBoard.SetActive(true);
                pageFound+=1;
                ChangedPosition();
                CreateInfoBox();
                var colors = artText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                artText.GetComponent<Button> ().colors = colors;
                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound;
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                artBool = false;
                artInt += 1;
            }
        }

        else if (sceneName == "HTML_Business")
        {
            if (businessInt == 1) {

                soundBoard.SetActive(true);
                pageFound+=1;
                ChangedPosition();
                CreateInfoBox();
                var colors = businessText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                businessText.GetComponent<Button> ().colors = colors;
                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound;
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                businessBool = false;
                businessInt += 1;
            }
        }

        else if (sceneName == "HTML_Finance")
        {
             if (financeInt == 1) {

                soundBoard.SetActive(true);
                pageFound+=1;
                ChangedPosition();
                CreateInfoBox();
                var colors = financeText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                financeText.GetComponent<Button> ().colors = colors;
                // ChangedPosition();
                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound;
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                financeBool = false;
                financeInt += 1;
            }
        }

        else if (sceneName == "HTML_ScienceTechnology")
        {
            if (techInt == 1) {

                soundBoard.SetActive(true);
                pageFound+=1;
                ChangedPosition();
                CreateInfoBox();
                var colors = sciTechText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                sciTechText.GetComponent<Button> ().colors = colors;
                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound;
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                techBool = false;
                techInt += 1;
            }
        }

        else if (sceneName == "HTML_Health")
        {
            if (healthInt == 1){
                
                soundBoard.SetActive(false);
                soundBoard.SetActive(true);
                pageFound+=1;
                ChangedPosition();
                CreateInfoBox();
                var colors = healthText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                healthText.GetComponent<Button> ().colors = colors;
                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound;
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                healthBool = false;
                healthInt += 1;
            }
        }

        else if (sceneName == "HTML_Sports")
        {
            if (sportsInt == 1){
                
                soundBoard.SetActive(true);
                pageFound+=1;
                ChangedPosition();
                CreateInfoBox();
                var colors = sportsText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                sportsText.GetComponent<Button> ().colors = colors;
                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound;
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                sportsBool = false;
                sportsInt += 1;
            }
        }

        else if (sceneName == "HTML_Entertainment")
        {
            if (entertainmentInt == 1) 
            {
                
                soundBoard.SetActive(true);
                pageFound+=1;
                entertainmentBool = false;
                ChangedPosition();

                CreateInfoBox();
                //entertainmentText.GetComponent<Button>().color = Color.red;
                var colors = entertainmentText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                entertainmentText.GetComponent<Button> ().colors = colors;

                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound + " of 6";
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                //currInfoBox.GetComponent<Text>().text = "Total Topics Discovered: \r\n" + pageFound;
                entertainmentInt += 1;
            }
                
        }

        else if (sceneName == "HTML_TourPage")
        {
            var colors = tourPageText.GetComponent<Button> ().colors;
            colors.normalColor = new Color32(128, 0, 128, 255);
            tourPageText.GetComponent<Button> ().colors = colors;

            
        }

        else if (sceneName == "HTML_News")
        {
            if (newsInt == 1) 
            {
                
                soundBoard.SetActive(true);
                pageFound+=1;
                //entertainmentBool = false;
                ChangedPosition();

                CreateInfoBox();
                //entertainmentText.GetComponent<Button>().color = Color.red;
                var colors =    newsText.GetComponent<Button> ().colors;
                colors.normalColor = new Color32(128, 0, 128, 255);
                newsText.GetComponent<Button> ().colors = colors;

                // currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
                // //res fix
                // currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

                // //the text
                // string myString = "Total Topics Discovered: \r\n" + pageFound + " of 6";
                // currInfoBox.GetComponent<BubbleScr>().SetText(myString);
                //currInfoBox.GetComponent<Text>().text = "Total Topics Discovered: \r\n" + pageFound;
                newsInt += 1;
            }
                
        }

        else if (sceneName == "HTML_Win")
        {
            
                
            //Destroy(this);
            currCanvas.SetActive(false);
                
        }

        else
        {
            Destroy(currInfoBox);
            soundBoard.SetActive(false);
        }

    }
    
    private void CreateInfoBox()
    {
        currInfoBox = Instantiate(infoBox, infoBoxPos, Quaternion.identity);
        //res fix
        currInfoBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, true);

        //the text
        string myString = "Total Topics Discovered: \r\n" + pageFound + " of 8";
        currInfoBox.GetComponent<BubbleScr>().SetText(myString);
    }

    private void ChangedPosition()
    {
        //currPos = new Vector3(tm.position.x - 5f, tm.position.y + 2f, 0f);
        currPos = new Vector3(tm.position.x + 6f, tm.position.y + 3.5f, 0f);
        infoBoxPos = Camera.main.WorldToScreenPoint(currPos);
    }
}
