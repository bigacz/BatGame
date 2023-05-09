using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainBallScript : MonoBehaviour
{
    public GameObject firework;
    public AudioSource fireworkSFX;
    public GameObject gameLogicScript;
    int BounceCount;
    float TimerMax = 0.2f;
    float Timer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 && gameLogicScript.GetComponent<GameLogicScript>().FireworkAdded == true)
        {
            BounceCount++;
           if (BounceCount > 1)
            {
                firework.SetActive(true);
                fireworkSFX.Play();
                Timer = TimerMax;
                BounceCount = 0;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Timer <= 0)
        {
            firework.SetActive(false);
        }
        else
        {
            Timer -= Time.deltaTime;
        }
        
    }
}
