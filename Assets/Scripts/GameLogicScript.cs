using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject LevelUpMenu;
    public heroScript heroScript;
    public GameObject heartBar;
    public GameObject xpFill;
    public GameObject levelText;

    public int Level;
    private float xpNeeded;
    private float xp;
    public float xpMultiplier;

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
        LevelUpMenu.SetActive(true);
        levelText.GetComponent<TMPro.TextMeshProUGUI>().text = "Lvl." + Level;
        Time.timeScale = 0f;
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
        Level = 0;
    }

}
