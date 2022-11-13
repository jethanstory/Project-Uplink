using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScr : MonoBehaviour
{
    public Text myText;
    public int timeNum;
    private int initialTimeNum;
    public int timeSpeed;
    private double counter = 0;
    public bool startCounting = false;

    public void Start()
    {
        initialTimeNum = timeNum;
    }

    public void Update()
    {
        if (startCounting)
        {
            counter += Time.deltaTime;

            if (counter >= (timeSpeed * Time.deltaTime))
            {
                timeNum--;
                counter = 0;
            }
        }

        if (timeNum < 0)
        {
            startCounting = false;
            FindObjectOfType<TextBoxScr>().GameOver();
            timeNum = initialTimeNum;
        }

        myText.text = timeNum.ToString();
    }

    public void DestroyTimer()
    {
        Destroy(gameObject);
    }

}
