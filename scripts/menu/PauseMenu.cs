using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused=false;

     private void Start()
    {
       PausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        isPaused=true;
        Time.timeScale = 0; 
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        isPaused=false;
        Time.timeScale = 1;
    }
}
