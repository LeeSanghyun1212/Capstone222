using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    bool isLive;    

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (rigid != null)
        {
            Vector2 dirVec = target.position - rigid.position;
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
        }   
    }
    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            // GameManager�� player�� null���� Ȯ��
            if (GameManager.Instance.player != null)
            {
                // player�� null�� �ƴϸ� target�� ����
                target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
            }
            else
            {
                Debug.LogWarning("GameManager's player is null.");
            }
        }

    }
}