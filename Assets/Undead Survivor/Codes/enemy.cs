using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 0f;
    public Rigidbody2D target;
    public float playtime = 0f;

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
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.EndGame();
            }
        }   
    }
    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            // GameManager의 player가 null인지 확인
            if (GameManager.Instance.player != null)
            {
                // player가 null이 아니면 target을 설정
                target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
            }
            else
            {
                Debug.LogWarning("GameManager's player is null.");
            }
        }

    }
}
