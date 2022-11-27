using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeamManagerScr : MonoBehaviour
{
    public Transform tm;
    public void RemoveLazerBeam()
    {
        for (int i = tm.childCount; i > 0; i--)
        {
            Destroy(tm.GetChild(i - 1).gameObject);
        }

        if (FindObjectOfType<BossLevelSpawnerScr>().gameOver == false)
        {
            FindObjectOfType<BossLevelSpawnerScr>().attackMove = Random.Range(0, 3);
            FindObjectOfType<BossLevelSpawnerScr>().canRun = true;
            FindObjectOfType<BossLevelSpawnerScr>().startMassiveAttack = false;
            FindObjectOfType<BossLevelSpawnerScr>().sr.color = Color.black;
            FindObjectOfType<CancelButtonScr>().hasStopped = false;
        }
        else
        {
            //game is over
            FindObjectOfType<BossLevelSpawnerScr>().attackMove = 4;
            FindObjectOfType<BossLevelSpawnerScr>().sr.color = Color.black;
        }
        
    }
}
