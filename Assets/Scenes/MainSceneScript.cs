using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneScript : MonoBehaviour
{
    public Button anyKeyButton;
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;

    public Text resolutionText;
    public Text volumeText;
    public Slider volumeSlider;
    public Text keyMappingText;
    public Button turnBackButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        resolutionText.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        keyMappingText.gameObject.SetActive(false);
        turnBackButton.gameObject.SetActive(false);

        anyKeyButton.onClick.AddListener(ShowMainTitle);

        optionsButton.onClick.AddListener(ShowMainOptions);
        exitButton.onClick.AddListener(GameExit);

        turnBackButton.onClick.AddListener(ShowMainTitle);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // anyKeyButton, turnBackButton
    private void ShowMainTitle()
    {
        anyKeyButton.gameObject.SetActive(false);

        startButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        resolutionText.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        keyMappingText.gameObject.SetActive(false);
        turnBackButton.gameObject.SetActive(false);
    }

    // optionsButton
    private void ShowMainOptions()
    {
        anyKeyButton.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        resolutionText.gameObject.SetActive(true);
        volumeText.gameObject.SetActive(true);
        volumeSlider.gameObject.SetActive(true);
        keyMappingText.gameObject.SetActive(true);
        turnBackButton.gameObject.SetActive(true);
    }
    // exitButton
    private void GameExit()
    {
        Application.Quit();
        Debug.Log("Game Exit");
    }

    // .
    private void SetObjectActive(bool active)
    {

    }
}
