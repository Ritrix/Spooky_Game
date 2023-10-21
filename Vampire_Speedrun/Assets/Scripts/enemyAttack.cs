using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    private float attackCooldown;
    public float startAttackCool;
    public Animator attackAnim;

    public bool playerClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = true;
            //attack, play animation
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCooldown <= 0)
        {
            //can attack
            attackCooldown = startAttackCool;
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }
}
