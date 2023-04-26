using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class enemyScript : MonoBehaviour
{ 
    public GameObject bat;
    public GameObject hero;

    private Vector2 target;
    private Vector2 heroPos;
    public float speed;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.layer == 8)
        {
            hero.GetComponent<heroScript>().TakeDamage();
        }
    }

    void Start()
    {
        hero = GameObject.Find("Hero");
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 6);

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        target = new Vector2(0.0f, 0.0f);
        heroPos = new Vector2(hero.transform.position.x, hero.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, heroPos, step);

    }
}
