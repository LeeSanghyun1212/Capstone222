using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseOnPlay : MonoBehaviour
{
    bool isPause;

    public Canvas pauseScreen;

    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;

    void Start()
    {
        isPause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
            {
                StartPause();
                return;
            }

            if (isPause == true)
            {
                StopPause();
                return;
            }
        }
    }

    public void StartPause()
    {
        Time.timeScale = 0;
        isPause = true;

        pauseScreen.gameObject.SetActive(true);
    }

    public void StopPause()
    {
        Time.timeScale = 1;
        isPause = false;

        pauseScreen.gameObject.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        
    }
}