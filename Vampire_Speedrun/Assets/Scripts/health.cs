using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public Animator deadAnim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void takeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0 )
        {
            //dead, play death animation (or cut to dead sprite)

        }
    }
}
