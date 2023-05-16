using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System.Threading.Tasks;


public class Rotation : MonoBehaviour
{   
    public GameObject levelControll;
    public GameObject charModel;
    public GameObject player;
    public GameObject playerCharmodel;
    public AudioSource seeYouAudio;
    public GameObject girl;
    public AudioSource countingAudio;


    bool rotate;
    bool dead = false;
    static public bool StartGame = false;
    static public bool looking = true;
    int count = 0;
  
    void Update () 
    { 
        if(!rotate && StartGame == true)
        {
            this.StartCoroutine(RotateObject());
        }
     }
    
     public void End()
     {
        //אם השחקן זז, כלומר נלחץ אחד החיצים במקלדת
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)  || Input.GetKey(KeyCode.LeftArrow)  || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Space)) && count%2==0)
        {  
            transform.position = new Vector3(player.transform.position.x, transform.position.y ,  transform.position.z);//המיקום של ציר האיקס של הסופרת משתנה למיקום של ציר האיקס של השחקן כדי שתוכל להצביע עליו
            dead = true;
            charModel.GetComponent<Animator>().Play("Male Action Pose");//מפעיל את האנימציה של ההצבעה
            // charModel.GetComponent<Animator>().Play("Pistol Idle");//מפעיל את האנימציה של ההצבעה
            seeYouAudio.Play();
            // transform.Rotate (new Vector3 (0, 0, -90));
            playerCharmodel.GetComponent<Animator>().Play("Golf Bad Shot");
            Debug.Log("I'm dead!");
            InputMover.canMove = false;//השחקן לא יכול לזוז ולשחק
            GameObject.Find("LevelControll").SendMessage("Finish");//מסתיים הספירה של הזמן
            levelControll.GetComponent<GameOverSequence>().enabled = true;//הפעלה של מסך הסיום
        }   
     }
    IEnumerator RotateObject()
     {
        if(InputMover.finish == false)
        {

        
        if(dead == false)
        {            
            count++;//סופר את הכיוון שאליו הסופרת מסתובבת
            
            if(count%2 == 1)
            {
            
            // girl.GetComponent<Animator>().Play("BackwardRotation");
            charModel.GetComponent<Animator>().Play("Aiming");


                countingAudio.Play(); 
                looking = false;
            }
            else
            {             
                girl.GetComponent<Animator>().Play("ForwardRotation");

                charModel.GetComponent<Animator>().Play("Northern Soul Spin Combo");
                // yield return new WaitForSeconds(0.05f);
                looking = true;

                charModel.GetComponent<Animator>().Play("Looking Around 1");
            }
        }

        rotate=true;
        for (int i = 0; i < 64; i++)
        {
             if(dead == false)
            {
                End(); 
            }
            yield return new WaitForSeconds(0.0625f);

        }
        rotate = false;
        }
    }

}