using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finnished = false;
    static public bool startTimer = false;
    public Text endTime;
    public Text endWinTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(finnished)
            return;
        if(startTimer == true)
        {
            float t = Time.time - startTime;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = "Time: "  + minutes + ":" + seconds;
            endTime.text = "Time: "  + minutes + ":" + seconds;
            endWinTime.text = "Time: "  + minutes + ":" + seconds;

        }
    }
     void Finish()
    {
        finnished =true;
        timerText.color = Color.yellow;
    }

}
