using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = globalVariables.health / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = globalVariables.health / 10;
    }
}
