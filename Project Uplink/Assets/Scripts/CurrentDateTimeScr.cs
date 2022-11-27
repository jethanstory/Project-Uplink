using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentDateTimeScr : MonoBehaviour
{
    // public static DateTime theTime = DateTime.Now; //the time
    // [SerializeField] private string date = theTime.ToString("yyyy-MM-dd\\Z"); //convert time and date to string
    // [SerializeField] private string time = theTime.ToString("HH:mm:ss");
    // [SerializeField] private string dateTime = theTime.ToString("yyyy-MM-dd\\THH:mm:ss\\Z");
    
    public GameObject textDisplay;


    // Start is called before the first frame update
    void Start()
    {
        string dateTime = System.DateTime.UtcNow.ToLocalTime().ToString("dddd M/d/yy  hh:mm tt");
        //string dateTime = System.DateTime.UtcNow.ToLocalTime().ToString("dddd M/d/yy");
        //userInput = searchBar.GetComponent<InputField>().text;
        textDisplay.GetComponent<Text>().text = dateTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
