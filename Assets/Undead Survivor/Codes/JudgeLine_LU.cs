using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JudgeLine2 : MonoBehaviour
{
    private bool isEnemyInRange = false;
    private List<Collider2D> enemiesInRange = new List<Collider2D>();
    GameObject obj;

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
        if (isEnemyInRange == true && Input.GetKeyDown(KeyCode.S))
        {
            foreach (var enemy in enemiesInRange)
            {
                Destroy(enemy);
            }
            enemiesInRange.Clear();
            isEnemyInRange = false;
            obj = GameObject.Find("Spawn");
            obj.GetComponent<Spawn>().spawntimer = 1f;
        }
    }
}