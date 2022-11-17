using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLoader : MonoBehaviour
{
   public float delayTimerScene; //= 5;
   public float delayTimerRam; //= 3;
   public string levelLoad= "Intro_Welcome";

   public GameObject defaultRam;

  void Start()
 {
   StartCoroutine(LoadRamOK(delayTimerRam)); 
   StartCoroutine(LoadLevelAfterDelay(delayTimerScene));
 }
 
 IEnumerator LoadLevelAfterDelay(float delayTimerScene)
 {
  yield return new WaitForSeconds(delayTimerScene);
  SceneManager.LoadScene(levelLoad);
  
 }

 IEnumerator LoadRamOK(float delayTimerRam)
 {
  yield return new WaitForSeconds(delayTimerRam);
  defaultRam.SetActive(true);
 }
}
