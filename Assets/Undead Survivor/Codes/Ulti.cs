using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Ulti : MonoBehaviour
{
    public static bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    public void Activative()
    {
        gameObject.SetActive(true);
    }

    public void UnActivative()
    {
        gameObject.SetActive(false);
    }
}
