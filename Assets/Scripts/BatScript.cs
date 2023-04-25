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
                bat.GetComponent<AreaEffector2D>().forceMagnitude = 0;
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
                bat.GetComponent<AreaEffector2D>().forceMagnitude = force;
                isIntTimer = true;
                isHitTimer = true;
                Debug.Log("jeb");
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
