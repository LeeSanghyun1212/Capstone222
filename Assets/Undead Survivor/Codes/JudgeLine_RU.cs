using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeLine : MonoBehaviour
{
    private bool isEnemyInRange = false;
    private List<Collider2D> enemiesInRange = new List<Collider2D>();

    GameObject obj;
    void Awake()
    {
        KeyBindings.LoadKeys();
    }

    void OnTriggerEnter2D(Collider2D other)
    { if (other.CompareTag("enemy"))
        {
            isEnemyInRange = true;
            enemiesInRange.Add(other);
        }
    }    
    void Update() 
    {
        if(!Player.sturnon && Player.finish == false)
        {
            if (isEnemyInRange == true && Input.GetKeyDown(KeyBindings.Judge_Line_RU))
            {
                //foreach (var enemy in enemiesInRange)
                //{
                //    enemy.gameObject.SetActive(false);
                //}
                //enemiesInRange.Clear();
                //isEnemyInRange = false;

                if (Player.ultimate)
                {

                }
                else
                {
                    Player.count += 1;
                    Player.killcount += 1;
                }

                if(Player.sturncnt > 0)
                {
                    Player.sturncnt--;
                }

                foreach (var enemy in enemiesInRange)
                {
                    Destroy(enemy);
                }

                enemiesInRange.Clear();
                isEnemyInRange = false;
                obj = GameObject.Find("Spawn");
                obj.GetComponent<Spawn>().spawntimer = 1f;
            }
            else if(isEnemyInRange != true && Input.GetKeyDown(KeyBindings.Judge_Line_RU))
            {
                Player.sturncnt++;
            }
        }
        else
        {

        }
    }
}