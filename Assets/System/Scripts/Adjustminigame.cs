using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class adjustminigame : MonoBehaviour
{
    public GameObject b1, b2, b3; //three bars
    Transform s1, s2, s3;
    float rate = 0.0012f; //base increase rate for the bars
    float scale; //current size of the bar
    int barsCompleted;
    Vector3 flat;
    float timer;

    void Start()
    {
        scale = 0; //bars start at 0
        barsCompleted = 0;

        s1 = b1.GetComponent<Transform>();
        s2 = b2.GetComponent<Transform>();
        s3 = b3.GetComponent<Transform>();

        flat = s1.transform.localScale;
        flat.x = 0.0001f;

        s1.localScale = flat;
        s2.localScale = flat; //set to 0
        s3.localScale = flat;
    }

    void Update()
    {
        scale += rate; //when the size of the bar reaches 0.77 it is full and so rate is inversed to start decrreasing it
        if ((scale >= 0.77) || (scale <= 0))
        {
            rate *= -1;
        }
        Vector3 temp = s1.localScale; //temporary vector for setting scale
        temp.x = scale;

        if (barsCompleted == 0)
        {
            s1.localScale = temp; //affects the appropriate bar depending on how many bars successfully adjusted
        }
        else if (barsCompleted == 1)
        {
            s2.localScale = temp;
        }
        if (barsCompleted == 2)
        {
            s3.localScale = temp;
        }
        if (barsCompleted == 3) //after all bars adjusted and two second timer elapsed, object destroys itself
        {
            if (Time.time > timer)
            {
                Destroy(this.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //stops the bar at the current scale. If within a certain range, moves on to the next bar
        {
            if (barsCompleted == 0)
            {
                if ((scale >= 0.31f) && (scale <= 0.47)) //1st bar, middle
                {
                    barsCompleted++;
                    scale = 0;
                    rate = 0.0012f;
                }
                else
                {
                    barsCompleted = 0; //if a bar is missed, progress resets for all bars
                    scale = 0;
                    rate = 0.0012f;
                    s1.localScale = flat;
                    s2.localScale = flat;
                    s3.localScale = flat;
                }
            }
            else if (barsCompleted == 1) 
            {
                if ((scale >= 0.06f) && (scale <= 0.22f)) //2nd bar, left
                {
                    barsCompleted++;
                    scale = 0;
                    rate = 0.0025f;
                }
                else
                {
                    barsCompleted = 0;
                    scale = 0;
                    rate = 0.0012f;
                    s1.localScale = flat;
                    s2.localScale = flat;
                    s3.localScale = flat;
                }
            }
            else if (barsCompleted == 2)
            {
                if ((scale >= 0.54f) && (scale <= 0.71f))//3rd bar, right
                {
                    barsCompleted++;
                    scale = 0;
                    rate = 0.0035f;
                    timer = Time.time + 2;
                }
                else
                {
                    barsCompleted = 0;
                    scale = 0;
                    rate = 0.0012f;
                    s1.localScale = flat;
                    s2.localScale = flat;
                    s3.localScale = flat;
                }
            }
            else { }
        }
    }
}
