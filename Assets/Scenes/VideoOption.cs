using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        // �� �ڵ尡 �۵����� ���� ���� ����

        int currentWidth = PlayerPrefs.GetInt("ScreenWidth", 1280);
        int currentHeight = PlayerPrefs.GetInt("ScreenHeight", 800);

        Screen.SetResolution(currentWidth, currentHeight, FullScreenMode.Windowed);

        InitUI();
    }

    // �ɼ� �޴��� �ػ� ��Ӵٿ� ����Ʈ ����
    void InitUI()
    {
        // �ػ� 800 �� 600 �̻�, �ߺ� ����
        resolutions = Screen.resolutions.Where(res => res.width >= 1024 && res.height >= 768).Distinct().ToList();

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

        // ��Ӵٿ� ��Ͽ��� ������ ������ �ػ� ����
        PlayerPrefs.SetInt("ScreenWidth", resolutions[index].width);
        PlayerPrefs.SetInt("ScreenHeight", resolutions[index].height);
        PlayerPrefs.Save(); // ������ ���� ����

        Debug.Log("�ػ� ������ " + resolutions[index].width + " �� " + resolutions[index].height + " " + resolutions[index].refreshRateRatio + "Hz�� �����");
    }
}