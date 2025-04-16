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
        angerValue = 1;
        canMove = true;
        isSleeping = false;
        anger = 0;
        angertime = 0.5f;
        angertimer = Time.time;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Boolean isMoving = false;

        if (isSleeping == true)
        {
            e.SetActive(false);
            if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.D)))
            {
                isSleeping = false;
                cam.GetComponent<CameraControl>().isSleeping = false;
                angerValue = 1;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Animator>().enabled = true;
                bed.GetComponent<Animator>().SetBool("sleeping", false);
                e.SetActive (true);
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Animator>().enabled = false;
            }
        }

        else if (canMove)
        {
            Vector3 temp = transform.position;
            tx = 0;
            ty = 0;

            if (Input.GetKey(KeyCode.W))
            {
                ty += 0.005f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                tx -= 0.005f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                ty -= 0.005f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                tx += 0.005f;
                isMoving = true;
            }

            if (temp.y > 0)
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

        

        if (Time.time > angertimer + angertime)
        {
            angertimer = Time.time + angertime;
            anger += angerValue;
            if (anger > 200) 
            {
                alien.GetComponent<Alien>().dialogue.text = "Yikes, looks like you blew a gasket. Better luck next time.";
                Destroy(this.gameObject); 
            }
        }

        s.value = anger;


        anim.SetBool("moving", isMoving);
        anim.SetInteger("anger", anger);

        if (tx > 0)
        {
            sr.flipX = true;
        }
        else if (tx < 0)
        {
            sr.flipX = false; 
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        e.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        e.SetActive(false);
    }
}
