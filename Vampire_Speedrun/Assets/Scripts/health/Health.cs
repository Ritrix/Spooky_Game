using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField]private float startingHealth;
    public float delayMax = 1f;
    public bool invincible = false;
    public float currentHealth;

    private void FixedUpdate()
    {
        currentHealth = globalVariables.health;
        if (globalVariables.health > 0)
        {
            //player hurt

        }
        else if (globalVariables.health <= 0)
        {
            //player dead

            SceneManager.LoadScene(4);
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        globalVariables.health = startingHealth;
    }

    public void takeDamage(float _damage)
    {
        if (!invincible)
        {
            //globalVariables.health = Mathf.Clamp(globalVariables.health - _damage, 0, startingHealth);
            globalVariables.health -= _damage;
            invincible = true;
            StartCoroutine(invincibleTiming());

            


        }



    }

    IEnumerator invincibleTiming()
    {
        invincible = true;
        yield return new WaitForSeconds(delayMax);
        invincible = false;
    }


}
