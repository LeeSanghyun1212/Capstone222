using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoint;

    public float spawntimer = 0;
    public static int timeLimit = 20;
    public int spawnnum = 0;
    int decoynum = 0;

    public GameObject obj;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Player.finish == false)
        {
            if (GameManager.surviveTime >= 0)
            {
                if (Player.killcount < 20)
                {
                    spawntimer += Time.deltaTime;
                }
                else
                {
                    Player.finish = true;
                }

                if (spawntimer >= 1f)
                {
                    spawnnum = Random.Range(1, 5);
                    spawntimer = 0;

                    if (decoynum == spawnnum && spawnnum < 4)
                    {
                        spawnnum += 1;
                    }
                    else if (decoynum == spawnnum && spawnnum >= 4)
                    {
                        spawnnum -= 1;
                    }
                    decoynum = spawnnum;
                }

                switch (spawnnum)
                {
                    case 1:
                        spawnnum = 0;
                        SpawnPosition_LD();
                        break;
                    case 2:
                        spawnnum = 0;
                        SpawnPosition_LU();
                        break;
                    case 3:
                        spawnnum = 0;
                        SpawnPosition_RD();
                        break;
                    case 4:
                        spawnnum = 0;
                        SpawnPosition_RU();
                        break;
                    default:
                        spawnnum = 0;
                        break;
                }
            }

            if (GameManager.surviveTime < 0)
            {
                GameObject.Find("Player").GetComponent<Player>().EndGame();
            }
        }
        else
        {

        }
            
    }
    void SpawnPosition_RU()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("enemy");
        Destroy(obj);
        GameObject enemy = GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoint[1].position;        
    }
    void SpawnPosition_LU()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("enemy");
        Destroy(obj);
        GameObject enemy2 = GameManager.Instance.pool.Get(0);
        enemy2.transform.position = spawnPoint[4].position;
    }
    void SpawnPosition_LD()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("enemy");
        Destroy(obj);
        GameObject enemy3 = GameManager.Instance.pool.Get(0);
        enemy3.transform.position = spawnPoint[3].position;
    }
    void SpawnPosition_RD()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("enemy");
        Destroy(obj);
        GameObject enemy4 = GameManager.Instance.pool.Get(0);
        enemy4.transform.position = spawnPoint[2].position;
    }
    public void Respawn()
    {
        spawntimer = 1f;
    }
}
