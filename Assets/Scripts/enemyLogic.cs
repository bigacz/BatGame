using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        Instantiate(enemy);
    }


    void Update()
    {

    }
}
