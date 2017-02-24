using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreGameController : MonoBehaviour {
    public Scene preGame;
    public Scene scene1;

    // Use this for initialization
    void Awake () {

        Time.timeScale = 0;

    }
   

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
          

    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    
  
}
