using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject cam;
    public GameObject p;
    Animator anim;
    bool canActivate;

    void Start()
    {
        canActivate = false; //starts unable to activate the bed. You are too far
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((canActivate == true) && Input.GetKeyDown(KeyCode.E)) //if you are close enough, and press e, you will go night-night
        {
            cam.GetComponent<CameraControl>().isSleeping = true; //camera focuses in on the bed
            p.GetComponent<NewBehaviourScript>().isSleeping = true;
            p.GetComponent<NewBehaviourScript>().angerValue = -5; //sleeping decreases anger every second
            anim.SetBool("sleeping", true); //plays the bed's sleeping animation while the player disappears to give the illusion of hopping into bed (Magic!)
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //determines whether the player is within range
    {
        canActivate = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canActivate = false;
    }
}
