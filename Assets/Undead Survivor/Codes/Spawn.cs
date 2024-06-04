using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer_LU, timer_LD, timer_RU, timer_RD;
    float spawntimer = 0;
    int spawnnum = 0;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        
        
    }
    // Update is called once per frame
    void Update()
    {
        //timer_lu += time.deltatime;
        //timer_ld += time.deltatime;
        //timer_ru += time.deltatime;
        //timer_rd += time.deltatime;
        //if (timer_lu > 1f)
        //{
        //    spawnposition_lu();
        //    timer_lu = 0;
        //}
        //else if (timer_ld > 1.4f)
        //{
        //    spawnposition_ld();
        //    timer_ld = 0;
        //}
        //else if (timer_ru > 1.7f)
        //{
        //    spawnposition_ru();
        //    timer_ru = 0;
        //}
        //else if (timer_rd > 1.9f)
        //{
        //    spawnposition_rd();
        //    timer_rd = 0;
        //}

        spawntimer += Time.deltaTime;

        if(spawntimer >= 1f)
        {
            spawnnum = Random.Range(1, 5);
            spawntimer = 0;
        }
        
        switch(spawnnum)
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
    void SpawnPosition_RU()
    {
        GameObject enemy = GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoint[1].position;        
    }
    void SpawnPosition_LU()
    {        
        GameObject enemy2 = GameManager.Instance.pool.Get(1);
        enemy2.transform.position = spawnPoint[4].position;       
    }
    void SpawnPosition_LD()
    {
        GameObject enemy3 = GameManager.Instance.pool.Get(2);
        enemy3.transform.position = spawnPoint[3].position;
    }
    void SpawnPosition_RD()
    {
        GameObject enemy4 = GameManager.Instance.pool.Get(3);
        enemy4.transform.position = spawnPoint[2].position;
    }
}
