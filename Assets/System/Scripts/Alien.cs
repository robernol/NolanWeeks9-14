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
        taskCompleted = true; //game starts off needing to talk to alien
    }

    void Update()
    {
        if (taskCompleted) //basically whenever you're not supposed to be completing a minigame
        {
            indicator.SetActive(true); //enables the spinning arow above him
            if (inRange) //if player is close enough
            {
                if (Input.GetKeyDown(KeyCode.E)) //pressing e randomly chooses a value from 1 to 4 and activates a certain minigame plus dialogue accordingly
                {
                    int minigameSelector = Random.Range(1, 5);
                    if (minigameSelector == 1)
                    {
                        debug.GetComponent<minigamestarter>().isActive = true; //minigame becomes active
                        dialogue.text = "Something's funky with the mainframe. Go debug it for me."; //text displays on the UI
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
                    indicator.SetActive(false); //arrow disappears
                    taskCompleted = false;  //disables talking to alien, now you have to go do a task
                    player.GetComponent<NewBehaviourScript>().anger += 10;  //the alien is a bit of a jerk so angers the player whenever you speak to him
                }
            }
        }
        else
        {
            indicator.SetActive(false); //if player should be completing minigame, disables the indicator
        }

    }
    private void OnCollisionEnter2D(Collision2D collision) //determines if player is close enough to activate with e. entering hitbox activates...
    {
        inRange = true; 
    }
    private void OnCollisionExit2D(Collision2D collision) //...exiting hitbox deactivates
    {
        inRange = false;
    }
}
