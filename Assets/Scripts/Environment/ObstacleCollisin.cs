using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisin : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;
    // public GameObject mainCam;
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            InputMover.notCrash = false;//השחקן לא ימשיך לרוץ
            this.gameObject.GetComponent<BoxCollider>().enabled = false; 
            // thePlayer.GetComponent<InputMover>().enabled = false;
            charModel.GetComponent<Animator>().Play("Stumble Backwards");//מפעיל את הנפילה אחורה
            crashThud.Play();
            // mainCam.GetComponent<Animator>().enabled = true;
            StartCoroutine(JumpSequence());
        }
        
       

    }

     IEnumerator JumpSequence()
     {
        yield return new WaitForSeconds(2f);
        InputMover.notCrash = true;
            thePlayer.transform.position = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y , thePlayer.transform.position.z-1.0f);
            this.gameObject.GetComponent<BoxCollider>().enabled = true; 

        // thePlayer.GetComponent<InputMover>().enabled = true;
        while (Rotation.looking == true)
        {
            yield return new WaitForSeconds(0.1f);

        }
        if(Rotation.looking == false){
            // if(thePlayer.transform.position.y > 1.0)
            // {
            // thePlayer.transform.position = new Vector3(thePlayer.transform.position.x, 1.0f , thePlayer.transform.position.z);
            // }

            // charModel.GetComponent<Animator>().Play("Idle");    
        }
     } 

   
}
