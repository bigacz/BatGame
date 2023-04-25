using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class BatScript : MonoBehaviour
{
    public GameObject bat;
    public GameObject ball;
    public GameObject hero;

    // Hit interval timer variables//
    public float hitInterval;
    private float intervalTimer;
    private bool isIntTimer = false;

    // Hit duration timer variables//
    public float hitDuration;
    private float hitTimer;
    private bool isHitTimer = false;



    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {

    }

    void Start()
    {
        intervalTimer = hitInterval;
        hitTimer = hitDuration;
    }

    void Update()
    {
        hit();
    }




    private void hit()
    {
        if (isHitTimer == true)
        {
            if (hitTimer > 0)
            {
                hitTimer -= Time.deltaTime;
            }
            else
            {
                isHitTimer = false;
                hitTimer = hitDuration;
                bat.GetComponent<BoxCollider2D>().enabled = false;
            }
        }



        if (isIntTimer == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bat.GetComponent<BoxCollider2D>().enabled = true;
                isIntTimer = true;
                isHitTimer = true;
            }
        }
        else
        {
            intTimer();

        }
    }

    private void intTimer()
    {
        if (intervalTimer > 0)
        {
            intervalTimer -= Time.deltaTime;
        }
        else
        {
            intervalTimer = hitInterval;
            isIntTimer = false;
        }
    }
}
