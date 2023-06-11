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
        yield return new WaitForSeconds(1.0f);
        InputMover.notCrash = true;
        thePlayer.GetComponent<InputMover>().enabled = true;
        while (Rotation.looking == true)
        {
            yield return new WaitForSeconds(0.1f);

        }
        if(Rotation.looking == false){
            if(thePlayer.transform.position.y > 0.0)
            {
            thePlayer.transform.position = new Vector3(thePlayer.transform.position.x, 0.3f , thePlayer.transform.position.z);
            }

            charModel.GetComponent<Animator>().Play("Idle");    
        }
     } 

   
}
