using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sign1Show : MonoBehaviour
{
    public TextMeshProUGUI diaText;
    public GameObject diaPanel;
    public string[] dialogue;

    public bool playerClose;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = true;
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
        if (playerClose)
        {
            if (diaPanel.activeInHierarchy)
            {

            }
            else
            {
                diaPanel.SetActive(true);
            }
        }
        else
        {
            diaPanel.SetActive(false);
        }

    }


}
