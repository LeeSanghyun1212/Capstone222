using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeLine : MonoBehaviour
{
    private bool isEnemyInRange = false;
    private List<Collider2D> enemiesInRange = new List<Collider2D>();


    void OnTriggerEnter2D(Collider2D other)
    { if (other.CompareTag("enemy"))
        {
            
            isEnemyInRange = true;
            enemiesInRange.Add(other);
        }
    }    
    void Update() 
    {
        if(!Player.sturnon)
        {
            if (isEnemyInRange == true && Input.GetKeyDown(KeyCode.J))
            {
                foreach (var enemy in enemiesInRange)
                {
                    enemy.gameObject.SetActive(false);
                }
                enemiesInRange.Clear();
                isEnemyInRange = false;

                if (Player.ultimate)
                {
                    Player.count = 0;
                    GuageBar.slidervalue = 0;
                }
                else
                {
                    Player.count += 1;
                    GuageBar.slidervalue += 1;
                }

                if(Player.sturncnt > 0)
                {
                    Player.sturncnt--;
                }
            }
            else if(isEnemyInRange != true && Input.GetKeyDown(KeyCode.J))
            {
                Player.sturncnt++;
            }
        }
        else
        {

        }
    }
}