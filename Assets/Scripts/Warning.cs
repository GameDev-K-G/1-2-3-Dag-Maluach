using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject warningText;

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            warningText.SetActive(true);   
            StartCoroutine(WarningPlayer());   
        }
       

    }
      IEnumerator WarningPlayer()
     {
        yield return new WaitForSeconds(2f);
        warningText.SetActive(false);   

          
     } 

}
