using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healScript : MonoBehaviour
{
    public GameObject hero;
    public heroScript heroScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
            if (heroScript.health < 3)
            hero.GetComponent<heroScript>().HealthChange(1);
        }
    }

    void Start()
    {
        hero = GameObject.Find("Hero");
        heroScript = hero.GetComponent<heroScript>();
    }

    void Update()
    {
        
    }
}
