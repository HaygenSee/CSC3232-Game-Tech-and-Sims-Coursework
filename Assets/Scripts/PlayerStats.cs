using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private float health = 0f;
    [SerializeField]
    private float max = 100f;

    private float kills = 0;

    private float enemyCount = 0;

    public Image HealthBar;

    public GameObject dead, player;


    private void Start()
    {
        health = max;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in enemies)
        {
            enemyCount += 1;
        }
    }

    public void updateHealth(float mod) 
    {
        health += mod;
        HealthBar.fillAmount = health / 100f;

        if (health <= 0f)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(currentScene.buildIndex);
        }
 
    }

    public bool checkKills()
    {
        kills += 1;
        if (kills == enemyCount)
        {
            return true;
        } else {
            return false;
        }
    }
}

