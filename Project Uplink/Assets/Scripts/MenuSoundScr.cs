using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSoundScr : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         Scene currentScene = SceneManager.GetActiveScene ();

        string sceneName = currentScene.name;

        
 
        if (sceneName == "Intro_Welcome" || sceneName == "Setup_1" || sceneName == "Setup_2") 
        {
            DontDestroyOnLoad(this);
            //Destroy(gameObject);
        }
        else
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
