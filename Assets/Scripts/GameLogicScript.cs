using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public heroScript heroScript;
    public GameObject heartBar;
    public void GameOver()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HeartBar(bool show)
    {
        heartBar.transform.GetChild(heroScript.health).gameObject.SetActive(show);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
}
