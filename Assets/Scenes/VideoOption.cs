using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class VideoOption : MonoBehaviour
{
    public Dropdown resolutionDropdownList;
    public Toggle fullScreenToggle;
    List<Resolution> resolutions = new List<Resolution>();

    void Start()
    {
        // 첫 실행 때에는 1280 × 800 해상도로 설정
        // 이 코드가 작동하지 않을 수도 있음

        int currentWidth = PlayerPrefs.GetInt("ScreenWidth", 1280);
        int currentHeight = PlayerPrefs.GetInt("ScreenHeight", 800);
        bool isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 0) == 1;

        Screen.SetResolution(currentWidth, currentHeight, FullScreenMode.Windowed);

        // 토글 상태 변경
        fullScreenToggle.isOn = isFullScreen;
        fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
        // 이벤트 리스너 추가

        InitUI();
    }

    // 옵션 메뉴의 해상도 드롭다운 리스트 생성
    void InitUI()
    {
        // 해상도 800 × 600 이상, 중복 제거
        resolutions = Screen.resolutions.Where(res => res.width >= 1024 && res.height >= 768).Distinct().ToList();

        resolutionDropdownList.options.Clear();

        int optionNum = 0;

        // 드롭다운 목록에 해상도 추가
        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();

            option.text = item.width + " × " + item.height + " " + item.refreshRateRatio + "Hz";

            resolutionDropdownList.options.Add(option);

            // 현재 어떤 해상도로 게임을 열어 두었나요?
            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdownList.value = optionNum;
            }
            optionNum++;

        }

        resolutionDropdownList.RefreshShownValue();
    }

    // 드롭다운에서 선택한 해상도를 적용
    public void SetScreenResolution(int index)
    {
        bool isFullScreen = fullScreenToggle.isOn;

        // isFullScreen이 true이면 전체 화면, 아니면 창 모드
        FullScreenMode screenMode = isFullScreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;

        Screen.SetResolution(resolutions[index].width, resolutions[index].height, screenMode, resolutions[index].refreshRateRatio);

        // 드롭다운 목록에서 선택한 것과 전체 화면 토글 버튼을 통해 해상도 지정
        PlayerPrefs.SetInt("ScreenWidth", resolutions[index].width);
        PlayerPrefs.SetInt("ScreenHeight", resolutions[index].height);
        PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save(); // 지정한 값을 저장

        Debug.Log("해상도 설정이 " + resolutions[index].width + " × " + resolutions[index].height + " " + resolutions[index].refreshRateRatio + "Hz로 변경됨");
    }

    public void SetFullScreen(bool isFullScreen)
    {
        FullScreenMode screenMode = isFullScreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;

        // 현재 해상도와 설정된 전체 화면 모드로 화면 설정
        Screen.SetResolution(Screen.width, Screen.height, screenMode);

        // 전체 화면 설정 저장
        PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log("전체 화면 모드: " + (isFullScreen ? "켜짐" : "꺼짐"));
    }
}