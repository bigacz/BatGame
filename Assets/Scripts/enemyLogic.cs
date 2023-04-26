using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    public GameObject enemy;
    public float Timer;
    public float spawnTime;
    void Start()
    {
        Instantiate(enemy);
        Timer = spawnTime;
    }


    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Instantiate(enemy);
            Timer = spawnTime;
        }
    }
}
