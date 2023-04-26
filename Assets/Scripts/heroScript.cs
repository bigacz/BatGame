using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroScript : MonoBehaviour
{
    public Rigidbody2D hero;
    public float MovementSpeed;
    public Camera cam;
    public Vector2 mousePosition;
    private Vector2 lookDirection;
    public int health; 
    
    
    void Start()
    {
    
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - hero.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        hero.rotation = lookAngle;
        Move();
    }

    private void Move()
    {
        Vertical();
        Horizontal();
    }

    private void Horizontal()
    {
        // Horizontal //
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            hero.velocity = new Vector2(10 * MovementSpeed, hero.velocity.y);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            hero.velocity = new Vector2(-10 * MovementSpeed, hero.velocity.y);
        }
        else
        {
            hero.velocity = new Vector2(0, hero.velocity.y);
        }
    }

    private void Vertical()
    {
        // Vertical //
        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            hero.velocity = new Vector2(hero.velocity.x, 10 * MovementSpeed);
        }
        else if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            hero.velocity = new Vector2(hero.velocity.x, -10 * MovementSpeed);
        }
        else
        {
            hero.velocity = new Vector2(hero.velocity.x, 0);
        }
    }

    public void TakeDamage()
    {
        health--;
    }
}
