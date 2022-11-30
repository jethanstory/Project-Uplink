using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLoader : MonoBehaviour
{
   public float delayTimerRam; //= 3;

   public GameObject defaultRam;

  void Start()
 {
   StartCoroutine(LoadRamOK(delayTimerRam));
 }

 IEnumerator LoadRamOK(float delayTimerRam)
 {
  yield return new WaitForSeconds(delayTimerRam);
  defaultRam.SetActive(true);
 }
}
