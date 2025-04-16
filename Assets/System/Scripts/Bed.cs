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
        canActivate = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((canActivate == true) && Input.GetKeyDown(KeyCode.E))
        {
            cam.GetComponent<CameraControl>().isSleeping = true;
            p.GetComponent<NewBehaviourScript>().isSleeping = true;
            p.GetComponent<NewBehaviourScript>().angerValue = -5;
            anim.SetBool("sleeping", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canActivate = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canActivate = false;
    }
}
