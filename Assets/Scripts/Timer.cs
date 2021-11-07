using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text showTime;
    public Text showPoints;
    public Text showAdditionalHearts;
    private float currentTime;
    [SerializeField] float playTime = 60f;
    private float pointsSeconds=0.0f;
    [SerializeField] float pointsEverySeconds = 1f;
    [SerializeField] float howMuchPointsEverySeconds = 20f;
    [SerializeField] float pointsOnHealing=10f;
    private float pointsCounter=0.0f;
    private int additionalHeartsCollected = 0;
    public static Timer instance;
    bool timeIsOver=false;
    GameWon_Lost gamewon_lost;

    public bool TimeIsOver
    {
        get
        {
            return timeIsOver;
        }
    }
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
    
        gamewon_lost = GameWon_Lost.instance;
        currentTime = playTime;
    }


    void Update()
    {
        if (!gamewon_lost.GameEnded)
        {
            if (currentTime > 0)
            {
                currentTime = playTime - Time.time;

                if (Time.time > pointsSeconds)
                {
                    pointsSeconds = Time.time + pointsEverySeconds;
                    pointsCounter += howMuchPointsEverySeconds;
                }
            }
            else
            {
                currentTime = 0;
                timeIsOver = true;
            }


            showTime.text = "Time left: " + Mathf.Round(currentTime);
            showPoints.text = $"Points: {pointsCounter}";
            showAdditionalHearts.text = $"Additional hearts: {additionalHeartsCollected}";
        }
    }
   public void pointsOnHealth()
    {
        pointsCounter += pointsOnHealing;
        additionalHeartsCollected += 1;
    }
    
}
