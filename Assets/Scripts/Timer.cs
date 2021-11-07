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
    private float pointsSeconds = 0.0f;
    [SerializeField] float pointsEverySeconds = 1f;
    [SerializeField] int howMuchPointsEverySeconds = 10;
    [SerializeField] int pointsOnHealing = 20;
    private int pointsCounter = 0;
    private int additionalHeartsCollected = 0;
    public static Timer instance;
    bool timeIsOver = false;
    GameWon_Lost gamewon_lost;
    float realTime;
    public float spawnBall1Seconds=10f;
    public float spawnBall2Seconds=15f;
    public GameObject Ball1;
    public GameObject Ball2;
    public Animator Excavator1;
    public Animator Excavator2;

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
       // PlayerPrefs.SetInt("Points", 0);              //For Clearing Progress
       // PlayerPrefs.SetInt("AdditionalHearts", 0);
        gamewon_lost = GameWon_Lost.instance;
        currentTime = playTime;
        realTime = Time.time;
    }


    void Update()
    {
        if (!gamewon_lost.GameEnded)
        {
            if (currentTime > 0)
            {
                currentTime = playTime - (Time.time - realTime);

                if (Time.time - realTime > pointsSeconds)
                {
                    pointsSeconds = Time.time - realTime + pointsEverySeconds;
                    pointsCounter += howMuchPointsEverySeconds;
                }

                if (Time.time - realTime > spawnBall1Seconds)
                {
                    spawnBall1Seconds = Time.time - realTime + spawnBall1Seconds;
                    Instantiate(Ball1);
                    Excavator1.Play("Ecscovator1_DefAnim");

                }
                if (Time.time - realTime > spawnBall2Seconds)
                {
                    spawnBall2Seconds = Time.time - realTime + spawnBall2Seconds;
                    Instantiate(Ball2);
                    Excavator2.Play("Ecscovator2_DefAnim");
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
            else
            {
                if (pointsCounter > PlayerPrefs.GetInt("Points"))
                    PlayerPrefs.SetInt("Points", pointsCounter);
                if (additionalHeartsCollected > PlayerPrefs.GetInt("AdditionalHearts"))
                    PlayerPrefs.SetInt("AdditionalHearts", additionalHeartsCollected);

            }
        }
        public void pointsOnHealth()
        {
            pointsCounter += pointsOnHealing;
            additionalHeartsCollected += 1;
        }

    }
