using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    public Dropdown resolutionDropdownList;
    List<Resolution> resolutions = new List<Resolution>();

    void Start()
    {
        // ù ���� ������ 1280 �� 800 �ػ󵵷� ����
        Screen.SetResolution(1280, 800, FullScreenMode.Windowed);

        InitUI();
    }

    // �ɼ� �޴��� �ػ� ��Ӵٿ� ����Ʈ ����
    void InitUI()
    {
        resolutions.AddRange(Screen.resolutions);

        resolutionDropdownList.options.Clear();

        int optionNum = 0;

        // ��Ӵٿ� ��Ͽ� �ػ� �߰�
        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();

            option.text = item.width + " �� " + item.height + " " + item.refreshRateRatio + "Hz";

            resolutionDropdownList.options.Add(option);

            // ���� � �ػ󵵷� ������ ���� �ξ�����?
            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdownList.value = optionNum;
            }
            optionNum++;

        }

        resolutionDropdownList.RefreshShownValue();
    }

    // ��Ӵٿ�� ������ �ػ󵵸� ����
    public void SetScreenResolution(int index)
    {
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, FullScreenMode.Windowed, resolutions[index].refreshRateRatio);
        Debug.Log("�ػ� ������ " + resolutions[index].width + " �� " + resolutions[index].height + " " + resolutions[index].refreshRateRatio + "Hz�� �����");
    }
}