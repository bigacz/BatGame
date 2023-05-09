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
    public GameObject heroBack;
    public GameLogicScript gameLogicScript;

    // Hit interval timer variables//
    public float hitInterval;
    private float intervalTimer;
    private bool isIntTimer = false;

    // Hit duration timer variables//
    public float hitDuration;
    private float hitTimer;
    private bool isHitTimer = false;

    // Animation, SFX//
    private Animator batAnim;
    public AudioSource hitSFX;
    public AudioSource swingSFX;

    // Bat physics //
    public float hitForce;
    public Vector3 ballPositon;
    public Vector2 hitDirection;
    public float hitAngle;
    public GameObject firework;

    // Jumbotron //
    public  int jumbotronMax;
    private int jumbotronCount;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            jumbotronCount++;
            if (jumbotronCount >= jumbotronMax)
            {
                gameLogicScript.Jumbotron();
                jumbotronCount = 0;
            }
            if (collider.gameObject != firework) 
            {
                collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                ballPositon = collider.transform.position;
                hitDirection = ballPositon - heroBack.transform.position;
                hitAngle = Mathf.Atan2(hitDirection.y, hitDirection.x) * Mathf.Rad2Deg;
                AddForceAtAngle(hitForce, hitAngle, collider.GetComponent<Rigidbody2D>());
                hitSFX.Play();
            }
        }
    }

    void Start()
    {
        intervalTimer = hitInterval;
        hitTimer = hitDuration;
        batAnim = GetComponent<Animator>();
        jumbotronMax = 131072;
    }

    void Update()
    {
        hit();
    }

    private void AddForceAtAngle(float force, float angle, Rigidbody2D rb)
    {
        angle *= Mathf.Deg2Rad;
        float xComponent = Mathf.Cos(angle) * force;
        float yComponent = Mathf.Sin(angle) * force;
        Vector2 forceApplied = new Vector2(xComponent, yComponent);

        rb.AddForce(forceApplied);
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
