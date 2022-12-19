using Assets.Scripts.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private GameControllerHelper helper;
    public List<ICharacter> heroes = new();
    public List<ICharacter> enemies = new();


    [Header("BattleStart Timer")]
    public float remainingTime;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    private void Awake()
	{
        helper = this.GetComponent<GameControllerHelper>();
	}

    void Start()
    {
        heroes = helper.GetHeroes();
        enemies = helper.GetEnemies();
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                DisplayTime(remainingTime);
            }
            else
            {
                Debug.Log("Time has run out!");
                OnBattleStart();
                remainingTime = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public delegate void BattleStartEventhandler(object source, EventArgs args);
    public event BattleStartEventhandler BattleStart;
    
    protected virtual void OnBattleStart()
    {
		BattleStart?.Invoke(this, EventArgs.Empty);
	}

    public int GenerateRandomNumber(int max)
	{
        return RandomNumberGenerator.GetInt32(max) + 1;
	}
}
