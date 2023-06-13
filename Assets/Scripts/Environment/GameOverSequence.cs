using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverSequence : MonoBehaviour
{
    public GameObject Timer;
    public AudioSource countingAudio;
    public AudioSource faildAudio;
    public GameObject endScreen;
    public GameObject levelControll;
    public GameObject highscore;
    



    // Start is called before the first frame update
    void Start()
    {
        
        Timer.SetActive(false);  
        StartCoroutine(EndScreen());   
    }
    IEnumerator EndScreen()
    {
        // Rotation.StartGame = false;//הילדה מתחילה להסתובב לספירה
        countingAudio.Stop();
        faildAudio.Play();
        yield return new WaitForSeconds(4f);
        endScreen.SetActive(true);   
    }
     public void saveresult()
    {
        endScreen.SetActive(false);;
        
        

        highscore.SetActive(true);
        
       
    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Rotation.StartGame = false;
    }
}
