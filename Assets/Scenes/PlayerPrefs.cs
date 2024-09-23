using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class KeyBindings
{
    public static KeyCode Judge_Line_LU = KeyCode.S;
    public static KeyCode Judge_Line_LD = KeyCode.D;
    public static KeyCode Judge_Line_RU = KeyCode.K;
    public static KeyCode Judge_Line_RD = KeyCode.J;
    public static KeyCode stunKey;

    // 키 저장
    public static void SaveKeys()
    {
        PlayerPrefs.SetString("Judge_Line_LU", Judge_Line_LU.ToString());
        PlayerPrefs.SetString("Judge_Line_LD", Judge_Line_LD.ToString());
        PlayerPrefs.SetString("Judge_Line_RU", Judge_Line_RU.ToString());
        PlayerPrefs.SetString("Judge_Line_RD", Judge_Line_RD.ToString());
        PlayerPrefs.SetString("stunKey", stunKey.ToString());
        PlayerPrefs.Save();
    }

    // 키 불러오기
    public static void LoadKeys()
    {
        Judge_Line_LU = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Judge_Line_LU", KeyCode.S.ToString()));
        Judge_Line_LD = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Judge_Line_LD", KeyCode.D.ToString()));
        Judge_Line_RU = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Judge_Line_RU", KeyCode.K.ToString()));
        Judge_Line_RD = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Judge_Line_RD", KeyCode.J.ToString()));

        stunKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("stunKey", KeyCode.K.ToString()));
    }
}

