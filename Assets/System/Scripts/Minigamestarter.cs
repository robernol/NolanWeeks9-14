using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class minigamestarter : MonoBehaviour
{
    bool canActivate;
    public bool isActive;
    public GameObject game, cam, p, indicator, alien; //game stores the minigame prefab
    public GameObject t;
    void Start()
    {
        canActivate = false; //not close enough at the start
    }

    void Update()
    {
        if (isActive)
        {
            indicator.SetActive(true); //when activated, the spinning arrow will let you know
        }

        if ((Input.GetKeyDown(KeyCode.E)) && (canActivate == true) && (t == null) && (isActive == true)) // have to be in range, game not already activated, and at correct game to activate with e
        {
            isActive = false; //sets to false so you can't play again  right after
            Vector3 temp = cam.transform.position; //spawns the minigame in the middle of the screen
            temp.z = -2;
            temp.y -= 0.2f;
            t = Instantiate(game, temp, transform.rotation); //instantiates game based on prefab loaded into gameobject game
            p.GetComponent<NewBehaviourScript>().canMove = false; //letting the player know they can no longer move, I don't know how to change the script name and am too scared of messing things up
        }

        if ((isActive == false) && (canActivate == true) && (indicator.activeSelf)) //once completing the game, and making sure you didn't just walk up to the wrong panel
        {
            indicator.SetActive(false); //disables the indicator
            alien.GetComponent<Alien>().taskCompleted = true; //reenables the indicator on the alien, and changes his text
            alien.GetComponent<Alien>().dialogue.text = "Finally. Now get back over here.";
        }
        
        if ((t == null) && canActivate == true) //when you are no longer playing a game (because it destroyed itself), you are returned your mobility
        {
            p.GetComponent<NewBehaviourScript>().canMove = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //checks if you are in range to activate game
    {
        canActivate = true;  
    }
    private void OnCollisionExit2D(Collision2D collision) //out of range
    {
        canActivate = false;
    }
}
