using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftRightSpeed = 4;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        // if(canMove == true){
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
            if(Input.GetKey(KeyCode.Space))
            {
                if(isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                }
            }
            
        // }

    }
}
