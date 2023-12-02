using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
     public static bool gamePaused = false;
     public GameObject pauseMenuInterface;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
               //if the game is already paused, resume the game else pause the game
               if (gamePaused)
               {
                    Resume();
               }
               else
               {
                    Pause();
               }
        }
    }

     public void Resume()
     {
          pauseMenuInterface.SetActive(false);
          Time.timeScale = 1f;
          gamePaused = false;
     }

     void Pause()
     {
          pauseMenuInterface.SetActive(true);
          Time.timeScale = 0f;
          gamePaused = true;
     }

     public void LoadMainMenu()
     {
          Time.timeScale = 1f;
          SceneManager.LoadScene("Menu");
     }

     public void Quit()
     {
          Application.Quit();
     }
}
