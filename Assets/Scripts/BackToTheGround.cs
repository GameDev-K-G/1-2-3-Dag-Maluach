using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTheGround : MonoBehaviour
{
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false; 

        if(thePlayer.gameObject.transform.parent==null)
        {

            thePlayer.gameObject.transform.position=new Vector3( thePlayer.gameObject.transform.position.x, 1.0f,  thePlayer.gameObject.transform.position.z);

        }

    }
}
