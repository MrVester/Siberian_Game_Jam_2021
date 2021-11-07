using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
      
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
