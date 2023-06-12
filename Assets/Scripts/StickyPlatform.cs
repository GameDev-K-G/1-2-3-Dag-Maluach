using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    public GameObject thePlayer;

    void OnTriggerEnter(Collider collision)
    {
    //    InputMover.notCrash = false;//השחקן לא ימשיך לרוץ

         if (collision.gameObject.name == "Player")
        {
            thePlayer.GetComponent<InputMover>().enabled = false;
            collision.gameObject.transform.SetParent(transform);
            StartCoroutine(Moving());

        }
    }
   
     IEnumerator Moving()
     {
        yield return new WaitForSeconds(0.1f);
        // InputMover.notCrash = true;
        thePlayer.GetComponent<InputMover>().enabled = true;
     }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}