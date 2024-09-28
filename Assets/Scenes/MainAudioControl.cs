using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainAudioControl : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    void Start()
    {
        float currentVolume = PlayerPrefs.GetFloat("AudioMaster", -20f);
        audioSlider.value = currentVolume;

    }

    public void AudioControl()
    {
        float sound = audioSlider.value;

        PlayerPrefs.SetFloat("AudioMaster", sound);
        PlayerPrefs.Save();

        SetVolume(sound);

    }

    private void SetVolume(float sound)
    {
        // 볼륨 조절 슬라이더의 값이 -40f 이하인 경우 음소거와 같은 것으로 처리
        if (sound == -40f)
        {
            masterMixer.SetFloat("AudioMaster", -80);
        }
        else
        {
            masterMixer.SetFloat("AudioMaster", sound);
        }
    }
}
