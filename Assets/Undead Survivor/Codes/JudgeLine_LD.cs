using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeLine3 : MonoBehaviour
{
    private bool isEnemyInRange = false;
    private List<Collider2D> enemiesInRange = new List<Collider2D>();

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
        if (isEnemyInRange == true && Input.GetKeyDown(KeyCode.D))
        {
            foreach (var enemy in enemiesInRange)
            {
                Destroy(enemy.gameObject);
            }
            enemiesInRange.Clear();
            isEnemyInRange = false;
        }
    }
}