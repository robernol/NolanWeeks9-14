using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordscript : MonoBehaviour
{
    public Animator anim;
    public AnimationClip attack;
    public GameObject swingHitbox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("HeroKnight_Attack1"))
        {
            swingHitbox.SetActive(true);
        }
        else
        {
            swingHitbox.SetActive(false);
        }
    }
}
