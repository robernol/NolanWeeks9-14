using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public bool canMove, isSleeping;
    public int anger, angerValue;
    Animator anim;
    float tx, ty;
    public GameObject e, cam, bed, alien;
    SpriteRenderer sr;
    public Slider s;
    float angertimer;
    float angertime;

    void Start()
    {
        angerValue = 1; //anger increases by 1 every anger time period
        canMove = true; //can move, not asleep
        isSleeping = false;
        anger = 0; //anger starts off at 0
        angertime = 0.5f;
        angertimer = Time.time;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        bool isMoving = false; //check every frame to tell if player has moved

        if (isSleeping == true) //when asleep, hides the interact button
        {
            e.SetActive(false);
            if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.D))) //upon moving, gets out
            {
                isSleeping = false;
                cam.GetComponent<CameraControl>().isSleeping = false; //puts everything back to normal, lets camera know to refocus on player
                angerValue = 1;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Animator>().enabled = true;
                bed.GetComponent<Animator>().SetBool("sleeping", false);
                e.SetActive (true);
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false; //if not moving, makes the player sprite disappear
                GetComponent<Animator>().enabled = false;
            }
        }

        else if (canMove)
        {
            Vector3 temp = transform.position;
            tx = 0;
            ty = 0;

            if (Input.GetKey(KeyCode.W)) //w moves player up
            {
                ty += 0.005f;
                isMoving = true; //lets game know player has moved this frame
            }

            if (Input.GetKey(KeyCode.A)) //a moves left
            {
                tx -= 0.005f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S)) //s down
            {
                ty -= 0.005f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.D)) //d right
            {
                tx += 0.005f;
                isMoving = true;
            }

            if (temp.y > 0) //changing layers around based on y position so that depending on where player is standing they will be either in front or behind the alien
            {
                temp.z = 3;
            }
            else
            {
                temp.z = 1;
            }

            temp.x += tx;
            temp.y += ty;
            transform.position = temp;
        }

        

        if (Time.time > angertimer + angertime) //when anger timer has elapsed, refreshes by adding the anger time back to the curent time
        {
            angertimer = Time.time + angertime;
            anger += angerValue; //every anger timer, adds the anger value to the anger total
            if (anger > 200)  //if you get too mad, you blow a gasket and die. You must sleep to prevent dying of angry
            {
                alien.GetComponent<Alien>().dialogue.text = "Yikes, looks like you blew a gasket. Better luck next time.";
                Destroy(this.gameObject); //player destroys itself
            }
        }

        s.value = anger; //lets slider know where to put the little player head icon on the anger meter


        anim.SetBool("moving", isMoving); //plays walking animation if the player has moved this frame
        anim.SetInteger("anger", anger); //as the player gets angrier, their sprite will reflect this. Changes at each 25 anger increment

        if (tx > 0) //if you moved to the left, flips you
        {
            sr.flipX = true;
        }
        else if (tx < 0) //if not, sets you back to normal
        {
            sr.flipX = false; 
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //detects when in the range of an object you can interact with. Will then enable the e button prompt above your head
    {
        e.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision) //detects when no longer in range
    {
        e.SetActive(false);
    }
}
