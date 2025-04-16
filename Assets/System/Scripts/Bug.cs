using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class bug : MonoBehaviour
{
    public debugminigame origin;
    bool dead;
    Animator anim;
    public float timer;
    void Start()
    {
        dead = false; //not yet, squishy one.
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (dead == true)
        {
            if (Time.time > timer) //once bug is squished, remains for a second then destroys itself
            {
                Object.Destroy(this.gameObject);
            }

        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) //if clicked on, bug becomes dead
        {
            if (!dead) //only happens if not already dead, otherwise you could squish one bug multiple times! :O
            {
                dead = true;
                anim.SetTrigger("squished"); //squish animation
                origin.squishedBugs++; //increases squished bugs count
                timer = Time.time + 1; //timer before bug disappears
            }
        }
            
    }

}
