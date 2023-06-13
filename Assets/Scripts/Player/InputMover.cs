using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
 [RequireComponent(typeof(CharacterController))]

public class InputMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] GameObject player;
    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveVertical  = new InputAction(type: InputActionType.Button);
    public bool isJumping = false;
    public GameObject levelControll;
    public GameObject girl;
    public bool comingDown = false;
    static public bool canMove = false;
    static public bool notMove = false;
    static public bool notCrash = true;
    bool boosting = false;
    float boostTimer = 0;
    bool injured = false;
    float injuredTimer = 0;
    float currentSpeed = 5; 
    public static bool finish = false;
    public AudioSource speedAudio;
    private CharacterController cc;
 
    void OnEnable()  {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()  
    {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }
    void Start()
    {
        currentSpeed= speed;
        cc = GetComponent<CharacterController>();
    }
    Vector3 velocity = new Vector3(0,0,0);

    void Update() 
    {
       
        if(canMove == true)
        {
            if(boosting == true) 
            {
                boostTimer += Time.deltaTime;
                if(boostTimer >= 3)
                {
                    currentSpeed = speed;
                    boostTimer = 0;
                    boosting = false;
                    // player.GetComponent<Animator>().Play("Idle");  

                }
            }
             if(injured == true) 
            {
                injuredTimer += Time.deltaTime;
                if(injuredTimer >= 10)
                {
                    currentSpeed = speed;
                    injuredTimer = 0;
                    injured = false;
                }
            } 
            // if(Input.GetKey(KeyCode.Space))
            // {
            //     if(isJumping == false)
            //     {
            //         notMove= false;//לא יופעל על השחקן האנימציה שהוא לא זז
            //         isJumping = true;
            //         player.GetComponent<Animator>().Play("Jump");
            //         StartCoroutine(JumpSequence());
            //     }
            // }
               float horizontal = moveHorizontal.ReadValue<float>();
               float vertical = moveVertical.ReadValue<float>();
                Vector3 movementVector = new Vector3(horizontal, 0, vertical) * currentSpeed * Time.deltaTime;
                
                 if(Input.GetKey(KeyCode.Space))
                {
                    
                    player.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                    isJumping= true;
                    notMove= true;

                    if(transform.position.y<8){
                        isJumping= true;
                        // StartCoroutine(JumpSequence());
                        movementVector = new Vector3(horizontal, gravity , vertical) * currentSpeed * Time.deltaTime;
                        transform.position += movementVector;
                    }
                    else{
                        if(transform.parent == null){
                            movementVector = new Vector3(horizontal, (-transform.position.y+1) , vertical) * currentSpeed * Time.deltaTime;
                            transform.position += movementVector;
                        }
                        
                    }
                    


                }
           else if (cc.isGrounded) 
            {
                  movementVector = new Vector3(horizontal, 0, vertical) * currentSpeed * Time.deltaTime;
               
               
                transform.position += movementVector;
            }
            
            else if(transform.parent == null)
             {
                movementVector = new Vector3(horizontal, (-transform.position.y+1) , vertical) * currentSpeed * Time.deltaTime;
                transform.position += movementVector;
            }
            else
             {
                movementVector = new Vector3(horizontal, 0 , vertical) * currentSpeed * Time.deltaTime;
                transform.position += movementVector;
            }
            //  velocity = transform.TransformDirection(velocity);
            //  cc.Move(velocity * Time.deltaTime);
        }
        // if(isJumping == true)
        // {
        //     // if(comingDown == false)
        //     // {
        //         // velocity.y += gravity*Time.deltaTime;
        //         transform.Translate(Vector3.up * Time.deltaTime * 15 *Time.deltaTime, Space.World);//קפיצה למעלה
        //     // }
        //      if(comingDown == true)
        //     {
        //         transform.Translate(Vector3.up * Time.deltaTime * -15 * Time.deltaTime, Space.World);//חזרה לאדמה
        //         // velocity.y -= gravity*Time.deltaTime;
        //          notMove = true;
        //     }
        // }
       

       if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftArrow)  && !Input.GetKey(KeyCode.RightArrow) && notMove == false && notCrash == true && Rotation.looking == false && !finish)
        {  
            if(!isJumping)
            {
                player.GetComponent<Animator>().Play("Idle");
            }
            
        }

        else if(notCrash == true && Rotation.looking == false && isJumping == false && !finish && !Input.GetKey(KeyCode.Space))
        {
            if(!Input.GetKey(KeyCode.Space)){
              player.GetComponent<Animator>().Play("Slow Run");  
            }
        }

    }  
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(1.10f);
        isJumping = false;
        comingDown = false;
        notMove = false;
    }
    

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "speedBoost")
        {
            speedAudio.Play();
            currentSpeed += (1.7f * currentSpeed);
            boosting = true;
            Destroy(other.gameObject);
        }
          if(other.tag == "Enemy")
        {
            currentSpeed -= currentSpeed/2;
            injured = true;
        }
        if(other.tag == "Finish")
        {
            finish = true;
            canMove=false;
            GameObject.Find("LevelControll").SendMessage("Finish");//מסתיים הספירה של הזמן
            levelControll.GetComponent<Win>().enabled = true;//הפעלה של מסך הסיום
            player.GetComponent<Animator>().Play("Dancing Maraschino Step");      
            girl.GetComponent<Animator>().Play("Sitting Disbelief");        


        }

    }
     void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == "Enemy")
        {
           currentSpeed = currentSpeed/2;
            injured = true;

        }
    }
 

    }