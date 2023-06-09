using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class enemyScript : MonoBehaviour
{ 
    public GameObject bat;
    public GameObject hero;
    public GameLogicScript gameLogicScript;


    private Vector2 heroPos;
    public float speed;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            Destroy(gameObject);
            gameLogicScript.xpAdd(10);
        }
        if (collider.gameObject.layer == 8)
        {
            hero.GetComponent<heroScript>().HealthChange(-1);
        }
    }

    void Start()
    {
        hero = GameObject.Find("Hero");
        gameLogicScript = GameObject.Find("GameLogic").GetComponent<GameLogicScript>();
        bat = GameObject.Find("Bat");
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 6);

    }

    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        float step = speed * Time.deltaTime;
        heroPos = new Vector2(hero.transform.position.x, hero.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, heroPos, step);
    }
}
