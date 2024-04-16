using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public GameObject day;
    public GameObject daylight;
    public GameObject night;
    public GameObject enemycontainer;
    public float timeRemaining = 100;
    public bool timerIsRunning = false;
    public Text timeText;
    

    private void Start()
    {
        night.SetActive(false);
        enemycontainer.SetActive(false);
        day.SetActive(true);
        daylight.SetActive(true);
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                day.SetActive(false);
                daylight.SetActive(false);
                night.SetActive(true);
                enemycontainer.SetActive(true);
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
}