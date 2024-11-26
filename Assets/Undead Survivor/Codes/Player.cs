using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public static float count = 0;
    public static int sturncnt = 0;
    public static int killcount = 0;
    public int imageIndex = 0;

    public static bool sturnon = false;
    public static bool finish = false;

    public Rigidbody2D rigid;
    public SpriteRenderer spriter;
    public Sprite[] attackSprites;

    public Ulti ulti;
    public GameObject ultiobj;

    public static bool ultimate = false;

    public GameObject darkPanel;
    public Text gameoverText;
    public Button restartBtn;
    public Button gotomainBtn;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;

        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        rigid.isKinematic = true;
        KeyBindings.LoadKeys();

        restartBtn.onClick.AddListener(gameoverRestart);
        gotomainBtn.onClick.AddListener(gameoverGomain);
    }
    
    // Update is called once per frame
    
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void Ultioff()
    {
        ultiobj.SetActive(false);
        ultimate = false;
    }

    void sturnoff()
    {
        Debug.Log("Can Move");
        sturncnt = 0;
        sturnon = false;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        darkPanel.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
        gotomainBtn.gameObject.SetActive(true);
    }

    void gameoverRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Play");
    }

    void gameoverGomain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    void LateUpdate()
    {
        if(ultimate && Player.finish == false)
        {
            if (Input.GetKeyDown(KeyBindings.Judge_Line_LU) || Input.GetKeyDown(KeyBindings.Judge_Line_LD))
            {
                if(imageIndex == 0)
                {
                    imageIndex = 1;
                }
                else if(imageIndex == 1)
                {
                    imageIndex = 0;
                }
                spriter.sprite = attackSprites[imageIndex];
                spriter.flipX = true; // ������ �ٶ󺸵��� ����
            }
            else if (Input.GetKeyDown(KeyBindings.Judge_Line_RU) || Input.GetKeyDown(KeyBindings.Judge_Line_RD))
            {
                if (imageIndex == 0)
                {
                    imageIndex = 1;
                }
                else if (imageIndex == 1)
                {
                    imageIndex = 0;
                }
                spriter.sprite = attackSprites[imageIndex];
                spriter.flipX = false; // �������� �ٶ󺸵��� ����
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyBindings.Judge_Line_LU) || Input.GetKeyDown(KeyBindings.Judge_Line_LD))
            {
                if (imageIndex == 0)
                {
                    imageIndex = 1;
                }
                else if (imageIndex == 1)
                {
                    imageIndex = 0;
                }
                spriter.sprite = attackSprites[imageIndex];
                spriter.flipX = true; // ������ �ٶ󺸵��� ����
            }
            else if (Input.GetKeyDown(KeyBindings.Judge_Line_RU) || Input.GetKeyDown(KeyBindings.Judge_Line_RD))
            {
                if (imageIndex == 0)
                {
                    imageIndex = 1;
                }
                else if (imageIndex == 1)
                {
                    imageIndex = 0;
                }
                spriter.sprite = attackSprites[imageIndex];
                spriter.flipX = false; // �������� �ٶ󺸵��� ����
            }

            //if (count >= 10 && Input.GetKeyDown(KeyCode.Space))
            //{
            //    GuageBar.reset = true;
            //    ultimate = true;

            //    count = 0;

            //    ultiobj.SetActive(true);

            //    Invoke("Ultioff", 5f);
            //}

            if (sturncnt > 3)
            {
                Debug.Log("Player Sturned!");
                sturnon = true;

                Invoke("sturnoff", 1f);
            }
        }
        
    }
}
