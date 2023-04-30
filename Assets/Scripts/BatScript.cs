using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class batScript : MonoBehaviour
{
    public GameObject bat;
    public GameObject hero;

    // Hit interval timer variables//
    public float hitInterval;
    private float intervalTimer;
    private bool isIntTimer = false;

    // Hit duration timer variables//
    public float hitDuration;
    private float hitTimer;
    private bool isHitTimer = false;

    private Animator batAnim;
    public AudioSource hitSFX;
    public AudioSource swingSFX;
    public float hitAngle;

    public Vector2 ballPosition;
    public Vector2 hitDirection;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            ballPosition = collider.transform.position;
            hitDirection = ballPosition - hero.GetComponent<Rigidbody2D>().position;
            hitAngle = Mathf.Atan2(hitDirection.y, hitDirection.x);
            hitSFX.Play();
            collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }


    void Start()
    {
        intervalTimer = hitInterval;
        hitTimer = hitDuration;
        batAnim = GetComponent<Animator>();
    }

    private void hit()
    {
        Debug.Log("elo");
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
                swingSFX.Play();
                batAnim.SetTrigger("TrOpen");
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
