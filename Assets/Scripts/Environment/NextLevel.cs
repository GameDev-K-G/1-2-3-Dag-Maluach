using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class NextLevel : MonoBehaviour
{
    [SerializeField] string sceneName;
  
    
    public void Restart()
    {
         InputMover.finish = false;
         SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
}
