using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    GameWon_Lost gamewon_lost;
    bool Switch=true;

    void Start()
    {
        gamewon_lost = GameWon_Lost.instance;
    }

    private void Update()
    {
        if (gamewon_lost.GameEnded&&Switch)
        {
            GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
            foreach (GameObject heart in hearts)
                GameObject.Destroy(heart);
            GameObject[] trashes = GameObject.FindGameObjectsWithTag("Trash");
            foreach (GameObject trash in trashes)
                GameObject.Destroy(trash);
            Switch = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Trash")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject);
        }
        

    }
}
