using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon_Lost : MonoBehaviour
{
    public GameObject Eraser;
   // private bool Switch = true;
    Timer timer;
    PlayerHealth playerHealth;
    public static GameWon_Lost instance;
    bool gameEnded = false;

    public bool GameEnded
    {
        get
        {
            return gameEnded;
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
        timer = Timer.instance;
        playerHealth = PlayerHealth.instance;
    }

    
    void Update()
    {
        if(!gameEnded && timer.TimeIsOver|| playerHealth.Health==0)
        {
            if(Eraser!=null)
            Eraser.SetActive(true);
            gameEnded = true;
        }
       /* if(!gameEnded && playerHealth.GameIsOver)
        {
            Eraser.SetActive(true);
            gameEnded = true;
        }*/
    }
}
