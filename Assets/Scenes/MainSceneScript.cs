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
    public Toggle resolutionToggle;
    public Text volumeText;
    public Slider volumeSlider;
    public Text keyMappingText;
    public Button turnBackButton;

    public Text mainTitleBef;
    public Text mainTitleAft;
    public Text optionTitle;
    public Button keymapButton;

    public Button keymapButton_LU;
    public Button keymapButton_LD;
    public Button keymapButton_RU;
    public Button keymapButton_RD;

    public Text keyMappingText_LU;
    public Text keyMappingText_LD;
    public Text keyMappingText_RU;
    public Text keyMappingText_RD;


    public KeyMappingButtonHandler keyMappingButtonHandler;
    // Start is called before the first frame update
    void Start()
    {
        if (keyMappingButtonHandler == null)
        {
            Debug.LogError("keyMappingButtonHandler is not assigned!");
        }
        mainTitleBef.gameObject.SetActive(true);
        mainTitleAft.gameObject.SetActive(false);
        optionTitle.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        resolutionText.gameObject.SetActive(false);
        resolutionDropdown.gameObject.SetActive(false);
        resolutionToggle.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        keyMappingText.gameObject.SetActive(false);
        turnBackButton.gameObject.SetActive(false);

        keymapButton.gameObject.SetActive(false);

        keymapButton_LU.gameObject.SetActive(false);
        keymapButton_LD.gameObject.SetActive(false);
        keymapButton_RU.gameObject.SetActive(false);
        keymapButton_RD.gameObject.SetActive(false);

        anyKeyButton.onClick.AddListener(ShowMainTitle);
        optionsButton.onClick.AddListener(ShowMainOptions);
        exitButton.onClick.AddListener(GameExit);
        turnBackButton.onClick.AddListener(ShowMainTitle);

        keymapButton.onClick.AddListener(ShowKeySetting);
        keymapButton_LU.onClick.AddListener(() => keyMappingButtonHandler.StartKeyMapping("LU"));
        keymapButton_LD.onClick.AddListener(() => keyMappingButtonHandler.StartKeyMapping("LD"));
        keymapButton_RU.onClick.AddListener(() => keyMappingButtonHandler.StartKeyMapping("RU"));
        keymapButton_RD.onClick.AddListener(() => keyMappingButtonHandler.StartKeyMapping("RD"));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void ShowKeySetting()
    {
        keymapButton_LU.gameObject.SetActive(true);
        keymapButton_LD.gameObject.SetActive(true);
        keymapButton_RU.gameObject.SetActive(true);
        keymapButton_RD.gameObject.SetActive(true);

        keyMappingText_LU.gameObject.SetActive(true);
        keyMappingText_LD.gameObject.SetActive(true);
        keyMappingText_RU.gameObject.SetActive(true);
        keyMappingText_RD.gameObject.SetActive(true);
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
        resolutionToggle.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        keyMappingText.gameObject.SetActive(false);
        turnBackButton.gameObject.SetActive(false);

        keymapButton.gameObject.SetActive(false);

        keymapButton_LU.gameObject.SetActive(false);
        keymapButton_LD.gameObject.SetActive(false);
        keymapButton_RU.gameObject.SetActive(false);
        keymapButton_RD.gameObject.SetActive(false);

        keyMappingText_LU.gameObject.SetActive(false);
        keyMappingText_LD.gameObject.SetActive(false);
        keyMappingText_RU.gameObject.SetActive(false);
        keyMappingText_RD.gameObject.SetActive(false);
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
        resolutionToggle.gameObject.SetActive(true);
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
