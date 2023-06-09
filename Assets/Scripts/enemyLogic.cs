using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemies;
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
            Instantiate(enemy, new Vector3(Random.Range(-6.66f, 6.66f),5), Quaternion.identity, enemies.transform);
            Timer = spawnTime;
        }
    }
}
