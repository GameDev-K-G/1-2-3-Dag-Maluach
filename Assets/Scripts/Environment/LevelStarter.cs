using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;


public class LevelStarter : MonoBehaviour
{
     public GameObject countDown3;
     public GameObject countDown2;
     public GameObject countDown1;
     public GameObject countDownGo;
     public GameObject clock;
     public GameObject Explantation;
     public AudioSource counting;
     public AudioSource startAudio;
     public GameObject levelControll;
     public GameObject Explantation2;
     //public TMP_InputField inputField;
     public TMP_InputField inputField;
     public Image mainw;
     


    

     public void StartGame()
     {
          // OpenNameInputDialog();
          StartCoroutine(CountSequence());   
     }
      public void ContinueButton()
     {
          Explantation.SetActive(false);
          Explantation2.SetActive(true);   
   
     }
        public void toContinueButton()
     {
         mainw.gameObject.SetActive(false);
          inputField.gameObject.SetActive(false);

          Explantation.SetActive(true);
             
   
     }
     IEnumerator CountSequence()
     {
          Explantation2.SetActive(false);
          yield return new WaitForSeconds(0.5f);
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
          levelControll.GetComponent<Timer>().enabled = true;
          clock.SetActive(true);  
          Timer.startTimer = true;

     }
   

     
}
