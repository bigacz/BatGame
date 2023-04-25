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

    public float force;

    // Hit interval timer variables//
    public float hitInterval;
    private float intervalTimer;
    private bool isIntTimer = false;

    // Hit duration timer variables//
    public float hitDuration;
    private float hitTimer;
    private bool isHitTimer = false;

    //Objects inside bat area variables//
    public int objCount;
    public Vector2 colliderPosition;
    public Vector2 punchDirection;
    public float punchAngle;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            objCount++;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.layer == 6)
        {
            objCount--;
        }
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

    public bool isEmpty()
    {
        return objCount == 0;
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
                if (isEmpty() == false)
                {
                    ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
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
