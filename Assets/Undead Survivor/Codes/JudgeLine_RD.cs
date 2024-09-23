using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeLineRD : MonoBehaviour
{
    private bool isEnemyInRange = false;
    private List<Collider2D> enemiesInRange = new List<Collider2D>();
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
    void Update()
    {
        if(!Player.sturnon)
        {
            if (isEnemyInRange == true && Input.GetKeyDown(KeyBindings.Judge_Line_RD))
            {
                foreach (var enemy in enemiesInRange)
                {
                    enemy.gameObject.SetActive(false);
                }
                enemiesInRange.Clear();
                isEnemyInRange = false;

                if (Player.ultimate)
                {

                }
                else
                {
                    Player.count += 1;
                    GuageBar.slidervalue += 1;
                }

                if (Player.sturncnt > 0)
                {
                    Player.sturncnt--;
                }
            }
            else if (isEnemyInRange != true && Input.GetKeyDown(KeyBindings.Judge_Line_RD))
            {
                Player.sturncnt++;
            }
        }
        else
        {

        }
        
    }
}