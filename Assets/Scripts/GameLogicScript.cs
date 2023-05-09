using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public heroScript heroScript;
    public GameObject pauseMenu;
    public GameObject LevelUpMenu;
    public GameObject heartBar;
    public GameObject xpFill;
    public GameObject levelText;
    public GameObject healHeart;
    public GameObject Balls;
    public GameObject golfBall;
    public GameObject enemies;
    public GameObject bat;
    public GameObject firework;

    public int Level;
    private float xpNeeded;
    private float xp;
    public float xpMultiplier;

    public Vector3 scaleChange;

    // Jumbotron //
    private bool JumbotronAdded;

    // Firework //
    public bool FireworkAdded;

    // Levels //
    public List<string> AbilitiesLevels = new List<string>();

    public string RandomLevel(List<string> Abilities)
    {
        Random.Range(0, Abilities.Count);

        return "elo";
    }

    public void Jumbotron()
    {
        int enemiesCount = enemies.transform.childCount;
        for (int i = 0; i < enemiesCount; i++)
        {
            Destroy(enemies.transform.GetChild(i).gameObject);
            xpAdd(10);
        }
    }

    public void xpAdd(float xpToAdd)
    {
        xp += xpToAdd * xpMultiplier;
        xpFill.GetComponent<Image>().fillAmount = xp / xpNeeded;
        if (xp >= xpNeeded)
        {
            LevelUp();
        }
    }

    public void levelFirework()
    {

        if (FireworkAdded == true)
        {
            firework.GetComponent<CircleCollider2D>().radius += 0.2f; 
        }
        else
        {
            FireworkAdded = true;
        }
        afterLevelUp();
    }

    public void levelSize()
    {
        golfBall.transform.localScale += scaleChange;
        int max = Balls.transform.childCount;
        for (int i = 0; i < max; i++)
        {
            Balls.gameObject.transform.GetChild(i).gameObject.transform.localScale += scaleChange;
            afterLevelUp();
        }

    }

    public void levelJumbotron()
    {

        if (JumbotronAdded == true)
        {
            bat.GetComponent<batScript>().jumbotronMax--;
        }
        else
        {
            bat.GetComponent<batScript>().jumbotronMax = 10;
            JumbotronAdded = true;
        }
        afterLevelUp();
    }

    public void levelMovement()
    {
        heroScript.MovementSpeed = (heroScript.MovementSpeed / 100) * 107;
        afterLevelUp();
    }

    public void levelBalls()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-6, 6), -1, 1);
        Instantiate(golfBall, spawnLocation, Quaternion.identity, Balls.transform);
        afterLevelUp();
    }

    public void levelHeal()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-6, 6), Random.Range(1, 4.5f), 1);
        Instantiate(healHeart, spawnLocation, Quaternion.identity);
        afterLevelUp();
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

    private void afterLevelUp()
    {
        Time.timeScale = 1.0f;
        xpFill.GetComponent<Image>().fillAmount = xp / xpNeeded;
        LevelUpMenu.SetActive(false);
    }

    public void GameOver()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HeartBar(bool show, int amount)
    {
        if (amount < 0)
        {
            heartBar.transform.GetChild(heroScript.health).gameObject.SetActive(show);
        }
        else
        {
            heartBar.transform.GetChild(heroScript.health - 1).gameObject.SetActive(show);
        }
    }

    private void Update()
    {
        
    }
    void Start()
    {
        golfBall.transform.localScale = new Vector3(1.25f, 1.25f, 1);
        xpNeeded = 100;
        Level = 0;

        LevelChances();
    }

    private void LevelChances()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < 5)
            {
                AbilitiesLevels.Add("levelSize");
                AbilitiesLevels.Add("levelJumbotron");
                AbilitiesLevels.Add("levelMovement");
                AbilitiesLevels.Add("levelBalls");
                AbilitiesLevels.Add("levelHeal");
            }
            if (i < 4)
            {

            }
            if (i < 3)
            {

            }
        }
    }
}
