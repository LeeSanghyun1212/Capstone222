using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoint;

    public float spawntimer = 0;
    public int spawnnum = 0;
    int decoynum = 0;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        spawntimer += Time.deltaTime;

        if(spawntimer >= 1f)
        {
            spawnnum = Random.Range(1, 5);
            spawntimer = 0;

            if(decoynum == spawnnum && spawnnum < 4)
            {
                spawnnum += 1;
            }
            else if(decoynum == spawnnum && spawnnum >= 4)
            {
                spawnnum -= 1;
            }

            decoynum = spawnnum;
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
