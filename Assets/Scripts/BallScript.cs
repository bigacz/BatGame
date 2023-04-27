using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public Collider2D ball;
    public Collider2D hero;


    void Start()
    {
        Physics2D.IgnoreCollision(ball,hero);
    }

    void Update()
    {
        
    }
}
