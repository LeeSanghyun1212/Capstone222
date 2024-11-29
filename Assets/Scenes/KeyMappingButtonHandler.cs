using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyMappingButtonHandler : MonoBehaviour
{
    public Button keymapButton_LU;
    public Button keymapButton_LD;
    public Button keymapButton_RU;
    public Button keymapButton_RD;

    public Text keyMappingText_LU;
    public Text keyMappingText_LD;
    public Text keyMappingText_RU;
    public Text keyMappingText_RD;

    private string currentKey = "";

    public void StartKeyMapping(string judgeLine)
    {
        currentKey = judgeLine;

        DisableKeymapButtons();
        StartCoroutine(WaitForKeyPress());
    }

    private void DisableKeymapButtons()
    {
        keymapButton_LU.interactable = false;
        keymapButton_LD.interactable = false;
        keymapButton_RU.interactable = false;
        keymapButton_RD.interactable = false;
    }

    private IEnumerator WaitForKeyPress()
    {
        while (true)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    switch (currentKey)
                    {
                        case "LU":
                            KeyBindings.Judge_Line_LU = keyCode;
                            UpdateKeyMappingText_LU(keyCode);
                            break;
                        case "LD":
                            KeyBindings.Judge_Line_LD = keyCode;
                            UpdateKeyMappingText_LD(keyCode);
                            break;
                        case "RU":
                            KeyBindings.Judge_Line_RU = keyCode;
                            UpdateKeyMappingText_RU(keyCode);
                            break;
                        case "RD":
                            KeyBindings.Judge_Line_RD = keyCode;
                            UpdateKeyMappingText_RD(keyCode);
                            break;
                    }
                    KeyBindings.SaveKeys();
                    currentKey = "";
                    EnableKeymapButtons();
                    yield break;
                }
            }
            yield return null;
        }
    }

    private void UpdateKeyMappingText_LU(KeyCode keyCode)
    {
        keyMappingText_LU.text = "LU Key: " + keyCode.ToString();
    }

    private void UpdateKeyMappingText_LD(KeyCode keyCode)
    {
        keyMappingText_LD.text = "LD Key: " + keyCode.ToString();
    }

    private void UpdateKeyMappingText_RU(KeyCode keyCode)
    {
        keyMappingText_RU.text = "RU Key: " + keyCode.ToString();
    }

    private void UpdateKeyMappingText_RD(KeyCode keyCode)
    {
        keyMappingText_RD.text = "RD Key: " + keyCode.ToString();
    }

    public void EnableKeymapButtons()
    {
        keymapButton_LU.interactable = true;
        keymapButton_LD.interactable = true;
        keymapButton_RU.interactable = true;
        keymapButton_RD.interactable = true;
    }
}