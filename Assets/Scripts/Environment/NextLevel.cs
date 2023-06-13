using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void Restart()
    {
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; 
    }
}
