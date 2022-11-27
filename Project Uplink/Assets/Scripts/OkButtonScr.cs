using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButtonScr : MonoBehaviour
{
    public GameObject errorMessage;
    public void BeginFight()
    {
        FindObjectOfType<BossLevelSpawnerScr>().canAttack = true;
        FindObjectOfType<CancelButtonScr>().hasStopped = false;
        FindObjectOfType<CancelButtonScr>().canBeDragged = true;
        FindObjectOfType<PercentageScr>().startCount = true;
        Destroy(errorMessage);
    }
}
