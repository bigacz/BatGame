using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject heartBar;
    public GameObject xpFill;

    public heroScript heroScript;
    public enemyLogic enemyLogic;


    public float Level;
    public float xpNeeded;
    public float xp;
    public float xpMultiplier;
    public float spawnTimePerLevel;

    public void xpAdd(float xpToAdd)
    {
        xp += xpToAdd * xpMultiplier;
        xpFill.GetComponent<Image>().fillAmount = xp / xpNeeded;
        if (xp >= xpNeeded)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {       
        xp = 0;
        xpNeeded += 10;
        Level++;
        enemyLogic.spawnTime -= spawnTimePerLevel;
    }

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
        xpNeeded = 100;
        Level = 1;
    }

}
