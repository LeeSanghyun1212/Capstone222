using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public static float count = 0;
    public static int sturncnt = 0;

    public static bool sturnon = false;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    Ulti ulti;
    public GameObject ultiobj;

    public static bool ultimate = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        rigid.isKinematic = true;
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
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
            spriter.flipX = true; // 왼쪽을 바라보도록 설정
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            spriter.flipX = false; // 오른쪽을 바라보도록 설정
        }

        if(count >= 10 && Input.GetKeyDown(KeyCode.Space))
        {
            GuageBar.reset = true;
            ultimate = true;

            count = 0;

            ultiobj.SetActive(true);

            Invoke("Ultioff", 5f);
        }

        if(sturncnt > 3)
        {
            Debug.Log("Player Sturned!");
            sturnon = true;

            Invoke("sturnoff", 1f);
        }
    }
}
