using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlankSceneScr : MonoBehaviour
{
    public float delayTimerScene; //= 5;
   public string levelLoad= "Credits_Scene";

  void Start()
 {
   StartCoroutine(LoadLevelAfterDelay(delayTimerScene));
 }
 
 IEnumerator LoadLevelAfterDelay(float delayTimerScene)
 {
  yield return new WaitForSeconds(delayTimerScene);
  SceneManager.LoadScene(levelLoad);
  
 }

}

