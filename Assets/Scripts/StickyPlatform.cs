using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
        public GameObject thePlayer;

    private void OnCollisionEnter(Collision collision)
    {
       InputMover.notCrash = false;//השחקן לא ימשיך לרוץ
         thePlayer.GetComponent<InputMover>().enabled = false;

         if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
        StartCoroutine(Moving());
    }
   
     IEnumerator Moving()
     {
        yield return new WaitForSeconds(0.1f);
        InputMover.notCrash = true;
        thePlayer.GetComponent<InputMover>().enabled = true;
     }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}