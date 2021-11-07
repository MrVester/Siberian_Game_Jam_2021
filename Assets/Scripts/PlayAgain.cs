using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public GameObject Game;
   
    void Start()
    {

    }

    public void ResetGame()
    {
        Application.LoadLevel("SampleScene");
    }
}
