using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image Panel; // Fade Out �̹��� ������Ʈ�� �����ϼ���.
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
            Debug.LogError("Panel ������ �Ҵ���� �ʾҽ��ϴ�!");
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
            Debug.LogError("Panel ������ �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    public void OnClickPlayButton()
    {
        StartFadeIn();

        // ���̵�ƿ� �� Play �� �ε�
        StartCoroutine(FadeOutAfterFadeIn());
    }

    IEnumerator FadeOutAfterFadeIn()
    {
        yield return new WaitForSeconds(F_time); // ���̵��� �ð���ŭ ���
        StartFadeOut();
        yield return new WaitForSeconds(F_time); // ���̵�ƿ� �ð���ŭ ���
        SceneManager.LoadScene("Play");
    }
}
