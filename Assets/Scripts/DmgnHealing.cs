using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgnHealing : MonoBehaviour
{
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = PlayerHealth.instance;
        /* playerHealth.DamageTaken += UpdateHearts;
         playerHealth.HealthUpgraded += AddHearts;*/
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            playerHealth.Heal();

        }
        if (collision.gameObject.tag == "Trash")
        {
            playerHealth.TakeDamage();

        }
        Destroy(collision.gameObject);
    }
    void Update()
    {

    }
}
