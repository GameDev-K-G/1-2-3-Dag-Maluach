using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornHit : MonoBehaviour
{
 
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;
    public GameObject mainCam;
    void OnTriggerEnter(Collider other)
    {
        InputMover.notCrash = false;//השחקן לא ימשיך לרוץ
        // this.gameObject.GetComponent<BoxCollider>().enabled = false; 
        thePlayer.GetComponent<InputMover>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");//מפעיל את הנפילה אחורה
        crashThud.Play();
        // mainCam.GetComponent<Animator>().enabled = true;
        StartCoroutine(JumpSequence());

    }

     IEnumerator JumpSequence()
     {
        
        {
            yield return new WaitForSeconds(0.1f);

        }
      
     } 

   
}
