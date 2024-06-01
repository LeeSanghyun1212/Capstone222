using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager pool;
    public Player player;
    public Text timeText;

    private float surviveTime;
    private bool isGameover;

    // Start is called before the first frame update
    private void Awake()
    {
        
        
        Instance = this;
        
    }
    void Start()
    {

        surviveTime = 0;
        isGameover = false;
    }
    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
             
    }
    
}
