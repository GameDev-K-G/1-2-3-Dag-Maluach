using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisin : MonoBehaviour
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
        yield return new WaitForSeconds(2.45f);
        InputMover.notCrash = true;
        if(Rotation.looking == false)
        charModel.GetComponent<Animator>().Play("Idle");    
        thePlayer.GetComponent<InputMover>().enabled = true;
    
     } 

   
}
