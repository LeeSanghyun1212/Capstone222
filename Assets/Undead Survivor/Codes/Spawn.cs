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
    public float spawnCycle = 1f;
    public static int timeLimit = 20;   //한 스테이지 제한 시간
    public static float killLimit = 1.0f;  //킬카운트를 올릴수있는 시간
    public int spawnnum = 0;
    public int spawnnumCP = 0;
    int decoynum = 0;
    int stageNum = 1;

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
                if (Player.count >= 3)
                {
                    if (Player.killcount > 0)
                    {
                        Player.killcount -= 1;
                    }
                    Player.count = 1;
                }

                if (Player.killcount < 10)
                {
                    spawntimer += Time.deltaTime;
                }
                else
                {
                    Player.finish = true;
                }

                if (spawntimer >= spawnCycle)
                {
                    switch (spawnnumCP)
                    {
                        case 1:
                            GameObject.Find("Line_LD").GetComponent<JudgeLine_LD>().ResetEnemiesInRange();
                            Debug.Log("지움LD");
                            break;
                        case 2:
                            GameObject.Find("Line_LU").GetComponent<JudgeLine_LU>().ResetEnemiesInRange();
                            Debug.Log("지움LU");
                            break;
                        case 3:
                            GameObject.Find("Line_RD").GetComponent<JudgeLineRD>().ResetEnemiesInRange();
                            Debug.Log("지움RD");
                            break;
                        case 4:
                            GameObject.Find("Line_RU").GetComponent<JudgeLine>().ResetEnemiesInRange();
                            Debug.Log("지움RU");
                            break;
                        default:
                            break;
                    }

                    spawnnum = Random.Range(1, 5);
                    
                    spawntimer = 0;
                    Player.count += 1;
                    
                    if (decoynum == spawnnum && spawnnum < 4)
                    {
                        spawnnum += 1;
                    }
                    else if (decoynum == spawnnum && spawnnum >= 4)
                    {
                        spawnnum -= 1;
                    }
                    decoynum = spawnnum;
                    spawnnumCP = spawnnum;
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
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Down");
                GameObject.Find("Player").GetComponent<Player>().anim.enabled = true;
                GameObject.Find("Player").GetComponent<Player>().anim.SetTrigger("Finish");
                GameObject obj = GameObject.FindWithTag("enemy");
                if(obj != null)
                {
                    Destroy(obj);
                }
                GameObject.Find("Player").GetComponent<Player>().PlayfinishSound();
                StartCoroutine(LevelUp());
            }
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

    IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(3.0f);
        Player.finish = false;
        Player.killcount = 0;
        GameManager.surviveTime = 21;

        //if(stageNum <= 2)
        //{
        //    spawnCycle -= 0.25f;
        //}
        //else if(stageNum <= 4)
        //{
        //    spawnCycle -= 0.1f;
        //}
        spawnCycle -= 0.25f;
        GameObject.Find("Player").GetComponent<Player>().anim.enabled = false;
        Debug.Log("OK");
    }
}
