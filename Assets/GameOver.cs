using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public void Retry ()
    {

        SceneManager.LoadScene("AstarTest");
      
    }

    

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
       
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitMenu()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }


}
