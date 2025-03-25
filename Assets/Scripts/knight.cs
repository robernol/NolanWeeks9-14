using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class knight : MonoBehaviour
{
    public float speed = 2;
    Animator animator;
    SpriteRenderer sr;
    AudioSource audsrc;
    ParticleSystem part;
    public AnimationCurve jump;
    public AudioClip f0, f1, f2, f3, f4, f5, f6, f7, f8, f9;
    public bool canRun = true;
    public bool isJumping = false;
    public float timer = -10;
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audsrc = GetComponent<AudioSource>();
        part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;

        animator.SetFloat("speed", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }
        if (canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && (isJumping == false))
        {
            timer = Time.time + 1;
            isJumping = true;
            
        }

        if (isJumping == true) 
        {
            if (timer - Time.time > 0)
            {
                Vector3 temp = transform.position;
                temp.y = jump.Evaluate(timer - Time.time);
                transform.position = temp;
            }
            else
            {
                isJumping = false;
                part.Play();
            }
        }
        animator.SetBool("jump", isJumping);
    }

    public void AttackHasFinished()
    {
        Debug.Log("attack donezo");
        canRun = true;
    }

    public void FootstepParticle()
    {
        AudioClip step = RandomFootstep();

        audsrc.PlayOneShot(step);
    }

    public AudioClip RandomFootstep()
    {
        int num = Random.Range(0, 10);

        List<AudioClip> footsteps = new List<AudioClip>();
        footsteps.Add(f0);
        footsteps.Add(f1);
        footsteps.Add(f2);
        footsteps.Add(f3);
        footsteps.Add(f4);
        footsteps.Add(f5);
        footsteps.Add(f6);
        footsteps.Add(f7);
        footsteps.Add(f8);
        footsteps.Add(f9);

        AudioClip rand = footsteps[num];
        return rand;
    }
}
