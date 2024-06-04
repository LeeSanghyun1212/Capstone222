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
    public Dropdown resolutionDropdown;
    public Text volumeText;
    public Slider volumeSlider;
    public Text keyMappingText;
    public Button turnBackButton;

    public Text mainTitleBef;
    public Text mainTitleAft;
    public Text optionTitle;
    public Button keymapButton;

    // Start is called before the first frame update
    void Start()
    {
        mainTitleBef.gameObject.SetActive(true);
        mainTitleAft.gameObject.SetActive(false);
        optionTitle.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        resolutionText.gameObject.SetActive(false);
        resolutionDropdown.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        keyMappingText.gameObject.SetActive(false);
        turnBackButton.gameObject.SetActive(false);

        keymapButton.gameObject.SetActive(false);

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
        mainTitleBef.gameObject.SetActive(false);
        mainTitleAft.gameObject.SetActive(true);
        optionTitle.gameObject.SetActive(false);

        anyKeyButton.gameObject.SetActive(false);

        startButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        resolutionText.gameObject.SetActive(false);
        resolutionDropdown.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        keyMappingText.gameObject.SetActive(false);
        turnBackButton.gameObject.SetActive(false);

        keymapButton.gameObject.SetActive(false);
    }

    // optionsButton
    private void ShowMainOptions()
    {
        anyKeyButton.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        resolutionText.gameObject.SetActive(true);
        resolutionDropdown.gameObject.SetActive(true);
        volumeText.gameObject.SetActive(true);
        volumeSlider.gameObject.SetActive(true);
        keyMappingText.gameObject.SetActive(true);
        turnBackButton.gameObject.SetActive(true);

        mainTitleAft.gameObject.SetActive(false);
        optionTitle.gameObject.SetActive(true);

        keymapButton.gameObject.SetActive(true);
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
