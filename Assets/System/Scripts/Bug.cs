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
        dead = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (dead == true)
        {
            if (Time.time > timer)
            {
                Object.Destroy(this.gameObject);
            }

        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!dead)
            {
                dead = true;
                anim.SetTrigger("squished");
                origin.squishedBugs++;
                timer = Time.time + 1;
            }
        }
            
    }

}
