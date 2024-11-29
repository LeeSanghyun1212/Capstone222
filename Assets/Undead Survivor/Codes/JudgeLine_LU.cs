using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeLine_LU : MonoBehaviour
{
    public bool isEnemyInRange = false;
    public List<Collider2D> enemiesInRange = new List<Collider2D>();

    GameObject obj;

    void Awake()
    {
        KeyBindings.LoadKeys();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            isEnemyInRange = true;
            enemiesInRange.Add(other);
        }
    }
    public void ResetEnemiesInRange()
    {
        foreach (var enemy in enemiesInRange)
        {
            Destroy(enemy);
        }

        enemiesInRange.Clear();
        isEnemyInRange = false;

    }
    void Update()
    {
        if (!Player.sturnon && Player.finish == false)
        {
            if (isEnemyInRange == true && Input.GetKeyDown(KeyBindings.Judge_Line_LU))
            {
                //foreach (var enemy in enemiesInRange)
                //{
                //    enemy.gameObject.SetActive(false);
                //}
                //enemiesInRange.Clear();
                //isEnemyInRange = false;



                foreach (var enemy in enemiesInRange)
                {
                    Destroy(enemy);
                }


                enemiesInRange.Clear();
                isEnemyInRange = false;
                Player.killcount += 1;


                if (Player.sturncnt > 0)
                {
                    Player.sturncnt--;
                }
                Player.count = 0;
                obj = GameObject.Find("Spawn");
                if (obj != null)
                {
                    obj.GetComponent<Spawn>().spawntimer = 1f;
                }
            }
            else if (isEnemyInRange != true && Input.GetKeyDown(KeyBindings.Judge_Line_LU))
            {
                Player.sturncnt++;
                Player.killcount = 0;
                Debug.Log("없는데 때림");
            }
        }
        else
        {

        }

    }

}