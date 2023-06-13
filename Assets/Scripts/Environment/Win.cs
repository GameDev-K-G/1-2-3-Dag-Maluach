using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winScreen;
    public AudioSource countingAudio;
    public GameObject Timer;
    public AudioSource VictoryAudio;
    public GameObject highscore;

    // Start is called before the first frame update
    void Start()
    {
      Timer.SetActive(false);  
      StartCoroutine(EndScreen());   
    }
      public void saveresult()
    {
      winScreen.SetActive(false);

        highscore.SetActive(true);
    }

    IEnumerator EndScreen()
    {
        countingAudio.Stop();
        VictoryAudio.Play();
        GameObject.Find("LevelControll").SendMessage("Finish");//מסתיים הספירה של הזמן
        yield return new WaitForSeconds(4f);
        winScreen.SetActive(true);   
    }
}
