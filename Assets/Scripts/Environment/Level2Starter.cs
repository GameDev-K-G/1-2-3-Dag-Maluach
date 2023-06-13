using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Starter : MonoBehaviour
{
     public GameObject countDown3;
     public GameObject countDown2;
     public GameObject countDown1;
     public GameObject countDownGo;
     public GameObject clock;
     public AudioSource counting;
     public AudioSource startAudio;
     public GameObject levelControll;

     void Start()
     {
          StartCoroutine(CountSequence());   
     }
    
     IEnumerator CountSequence()
     {
          Debug.Log("I'm in Level 2 script");
          countDown3.SetActive(true);//מפעיל את הספרה 3
          startAudio.Play();
          yield return new WaitForSeconds(1f);
          countDown2.SetActive(true);
          yield return new WaitForSeconds(1f);
          countDown1.SetActive(true);
          yield return new WaitForSeconds(1f);
          countDownGo.SetActive(true);
          InputMover.canMove = true;//השחקן יכול להתחיל לזוז ולשחק
          yield return new WaitForSeconds(1f);
          //    counting.Play();//הפעלת הספירה של הילדה
          Rotation.StartGame = true;//הילדה מתחילה להסתובב לספירה
          Rotation.looking = false;//הילדה מתחילה להסתובב לספירה
          levelControll.GetComponent<Timer>().enabled = true;
          clock.SetActive(true);  
          Timer.startTimer = true;

     }
}
