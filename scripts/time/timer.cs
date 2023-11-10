using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public string sceneToLoad;
    public string sceneToLoad2;
    public SuspectListManager suspectListManager;
    public float countdownTime = 300.0f;
    private float currentTime;
    private bool timerActive = true;

    private static Timer instance; // A reference to the timer instance.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.root.gameObject); // Don't destroy the root object of the TimerManager.
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates.
        }

        currentTime = countdownTime;
    }

    private void Update()
    {
        if (timerActive)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timerActive = false;
                currentTime = 0;

                if (suspectListManager != null && suspectListManager.IsPlayerFirst())
                {
                    SceneManager.LoadScene(sceneToLoad2);
                    Destroy(transform.root.gameObject);
                }
                else
                {
                    SceneManager.LoadScene(sceneToLoad);
                    Destroy(transform.root.gameObject);
                }
            }
            
        }
        // Check if the current scene is the one where you want to destroy the TimerCanvas.
    
    }

    private void UpdateTimerDisplay()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
    }
}
