using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
     public static bool game_paused = false;
     public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          //if the game is already paused, resume the game
          if (game_paused)
          {
               ResumeGame();
          }
          //else pause the game
          else
          {
               PauseGame();
          }
        }
          
    }

     //Deactivate pause menu, set time to normal time, and set bool to false;
     public void ResumeGame()
     {
          pauseMenuUI.SetActive(false); 
          Time.timeScale = 1f;
          game_paused = false;
     }
     //Bring up pause menu, freeze the game, and set bool to true
     void PauseGame()
     {
          pauseMenuUI.SetActive(true);
          Time.timeScale = 0f;
          game_paused = true;
     }

     public void LoadMainMenu()
     {
          //unpauses the game when going to the main menu
          Time.timeScale = 1f;
          SceneManager.LoadScene("Menu");
     }

     public void QuitGame()
     {
          Application.Quit();
     }
}
