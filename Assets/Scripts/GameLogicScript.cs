using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public void GameOver()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
}
