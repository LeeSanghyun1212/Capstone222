using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image Panel; // Fade Out 이미지 컴포넌트를 연결하세요.
    float time = 0f;
    float F_time = 1f;

    public void StartFadeIn()
    {
        StartCoroutine(FadeInFlow());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeInFlow()
    {
        if (Panel != null)
        {
            Panel.gameObject.SetActive(true);
            Color alpha = Panel.color;
            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);
                Panel.color = alpha;
                yield return null;
            }
        }
        else
        {
            Debug.LogError("Panel 변수가 할당되지 않았습니다!");
        }
    }

    IEnumerator FadeOutFlow()
    {
        if (Panel != null)
        {
            Color alpha = Panel.color;
            while (alpha.a > 0f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(1, 0, time);
                Panel.color = alpha;
                yield return null;
            }
            Panel.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Panel 변수가 할당되지 않았습니다!");
        }
    }

    public void OnClickPlayButton()
    {
        StartFadeIn();

        // 페이드아웃 후 Play 씬 로드
        StartCoroutine(FadeOutAfterFadeIn());
    }

    IEnumerator FadeOutAfterFadeIn()
    {
        yield return new WaitForSeconds(F_time); // 페이드인 시간만큼 대기
        StartFadeOut();
        yield return new WaitForSeconds(F_time); // 페이드아웃 시간만큼 대기
        SceneManager.LoadScene("Play");
    }
}
