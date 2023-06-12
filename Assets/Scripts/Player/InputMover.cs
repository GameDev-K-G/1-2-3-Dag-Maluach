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
        // this.transform.position=new Vector3(this.transform.position.x, 1.0f, this.transform.position.z);
        currentSpeed= speed;
        cc = GetComponent<CharacterController>();
    }
    Vector3 velocity = new Vector3(0,0,0);

    void Update() 
    {
        // if(this.transform.parent==null && isJumping==false && !Input.GetKey(KeyCode.Space))
        // {
        //     this.transform.position=new Vector3(this.transform.position.x, 1.0f, this.transform.position.z);

        // }
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
                    player.GetComponent<Animator>().Play("Idle");  

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
            if(Input.GetKey(KeyCode.Space))
            {
                if(isJumping == false)
                {
                    notMove= false;//לא יופעל על השחקן האנימציה שהוא לא זז
                    isJumping = true;
                    player.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }
       
                
            if (cc.isGrounded) 
            {
                velocity.x = moveHorizontal.ReadValue<float>() * currentSpeed;
                velocity.z = moveVertical.ReadValue<float>() * currentSpeed;
                // Vector3 movementVector = new Vector3(horizontal, 0, vertical) * currentSpeed * Time.deltaTime;
                // transform.position += movementVector;
            }
            
            else {
                velocity.y -= gravity*Time.deltaTime;
            }
             velocity = transform.TransformDirection(velocity);
             cc.Move(velocity * Time.deltaTime);
        }
        if(isJumping == true)
        {
            // if(comingDown == false)
            // {
                velocity.y += gravity*Time.deltaTime;
                // transform.Translate(Vector3.up * Time.deltaTime * 15, Space.World);//קפיצה למעלה
            // }
             if(comingDown == true)
            {
                // transform.Translate(Vector3.up * Time.deltaTime * -15, Space.World);//חזרה לאדמה
                velocity.y -= gravity*Time.deltaTime;
                 notMove = true;
            }
        }
       

       if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)  && !Input.GetKey(KeyCode.LeftArrow)  && !Input.GetKey(KeyCode.RightArrow) && notMove == false && notCrash == true && Rotation.looking == false && !finish)
        {  
            if(!isJumping)
            {
                player.GetComponent<Animator>().Play("Idle");
            }
            
        }

        else if(notCrash == true && Rotation.looking == false && isJumping == false && !finish)
        {
              player.GetComponent<Animator>().Play("Slow Run");  
        }

    }  
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        notMove = false;
        player.GetComponent<Animator>().Play("Idle");        
    }
    

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "speedBoost")
        {
            speedAudio.Play();
            player.GetComponent<Animator>().Play("Fast Run");
            currentSpeed = (2 * currentSpeed);
            boosting = true;
            Destroy(other.gameObject);
        }
          if(other.tag == "Enemy")
        {
            currentSpeed = currentSpeed/5;
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
    //    InputMover.notCrash = false;//השחקן לא ימשיך לרוץ

         if (collision.gameObject.tag == "Enemy")
        {
            // thePlayer.GetComponent<InputMover>().enabled = false;
           currentSpeed = currentSpeed/5;
            injured = true;

        }
    }
 

    }