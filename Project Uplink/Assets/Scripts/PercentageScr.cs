using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageScr : MonoBehaviour
{
    public bool startCount = false;
    public float maxTime;
    private float counter = 0;
    public int percentageNum = 0;
    public Text percent;

    public void Update()
    {
        if (startCount)
        {
            //counter += Time.deltaTime;
            counter += Time.deltaTime+1;

            if (counter >= (maxTime * Time.deltaTime))
            {
                percentageNum++;
                counter = 0;
            }
        }

        percent.text = percentageNum.ToString() + "%";

        if (percentageNum >= 100)
        {
            startCount = false;
            FindObjectOfType<BossLevelSpawnerScr>().gameOver = true;
        }
    }
}
