//using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject indicator, player, debug, adjust, orient, retune;
    public TMP_Text dialogue;
    public bool taskCompleted, inRange;
    void Start()
    {
        taskCompleted = true;
    }

    void Update()
    {
        if (taskCompleted)
        {
            indicator.SetActive(true);
            if (inRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    int minigameSelector = Random.Range(1, 5);
                    if (minigameSelector == 1)
                    {
                        debug.GetComponent<minigamestarter>().isActive = true;
                        dialogue.text = "Something's funky with the mainframe. Go debug it for me.";
                    }
                    if (minigameSelector == 2)
                    {
                        orient.GetComponent<minigamestarter>().isActive = true;
                        dialogue.text = "The ship's navigation is off. Whatever you did, go fix it.";
                    }
                    if (minigameSelector == 3)
                    {
                        adjust.GetComponent<minigamestarter>().isActive = true;
                        dialogue.text = "All the pressure and whatnot is destabilized in the engine. Get it sorted.";
                    }
                    if (minigameSelector == 4)
                    {
                        retune.GetComponent<minigamestarter>().isActive = true;
                        dialogue.text = "Hye, cna ouy earh me? heT otnalrastr mtus be deriablaectd. Gte on hwit it!";
                    }
                    indicator.SetActive(false);
                    taskCompleted = false;
                    player.GetComponent<NewBehaviourScript>().anger += 10;
                }
            }
        }
        else
        {
            indicator.SetActive(false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        inRange = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        inRange = false;
    }
}
