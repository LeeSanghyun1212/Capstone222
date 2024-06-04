using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseOnPlay : MonoBehaviour
{
    bool isPause;

    public Canvas pauseScreen;

    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;

    public AudioSource audioBgm;

    void Start()
    {
        isPause = false;
    }

    void Update()
    {
        // ESC Ű Ŭ���� Ȯ�εǸ�
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

    // ���� �� �Ͻ������� ����
    public void StartPause()
    {
        Time.timeScale = 0;
        isPause = true;

        audioBgm.Pause();
        pauseScreen.gameObject.SetActive(true);
    }

    // ���� �� �Ͻ������� ����
    public void StopPause()
    {
        Time.timeScale = 1;
        isPause = false;

        audioBgm.Play();
        pauseScreen.gameObject.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        Time.timeScale = 1;
        isPause = false;
        pauseScreen.gameObject.SetActive(false);

        SceneManager.LoadScene("Main");
    }

    public void OnClickRestartButton()
    {
        Time.timeScale = 1;
        isPause = false;
        pauseScreen.gameObject.SetActive(false);

        SceneManager.LoadScene("Play");
    }
}