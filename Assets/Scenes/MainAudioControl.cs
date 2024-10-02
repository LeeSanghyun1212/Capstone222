using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainAudioControl : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    // ó�� ���� �� ����� ������ ���� -20f���� ���� �� �����̴��� ����
    void Start()
    {
        float currentVolume = PlayerPrefs.GetFloat("AudioMaster", -20f);
        audioSlider.value = currentVolume;

    }

    public void AudioControl()
    {
        float sound = audioSlider.value;

        // PlayerPrefs�� ����� ������ ���� ����
        PlayerPrefs.SetFloat("AudioMaster", sound);
        PlayerPrefs.Save(); // ������ ���� ����

        SetVolume(sound);

    }

    private void SetVolume(float sound)
    {
        // ���� ���� �����̴��� ���� -40f ������ ��� ���Ұſ� ���� ������ ó��
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
