using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class adjustminigame : MonoBehaviour
{
    public GameObject b1, b2, b3;
    Transform s1, s2, s3;
    float rate = 0.0012f;
    float scale;
    int barsCompleted;
    Vector3 flat;
    float timer;

    void Start()
    {
        scale = 0;
        barsCompleted = 0;

        s1 = b1.GetComponent<Transform>();
        s2 = b2.GetComponent<Transform>();
        s3 = b3.GetComponent<Transform>();

        flat = s1.transform.localScale;
        flat.x = 0.0001f;

        s1.localScale = flat;
        s2.localScale = flat;
        s3.localScale = flat;
    }

    void Update()
    {
        scale += rate;
        if ((scale >= 0.77) || (scale <= 0))
        {
            rate *= -1;
        }
        Vector3 temp = s1.localScale;
        temp.x = scale;

        if (barsCompleted == 0)
        {
            s1.localScale = temp;
        }
        else if (barsCompleted == 1)
        {
            s2.localScale = temp;
        }
        if (barsCompleted == 2)
        {
            s3.localScale = temp;
        }
        if (barsCompleted == 3)
        {
            if (Time.time > timer)
            {
                Destroy(this.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (barsCompleted == 0)
            {
                if ((scale >= 0.31f) && (scale <= 0.47))
                {
                    barsCompleted++;
                    scale = 0;
                    rate = 0.0012f;
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
            else if (barsCompleted == 1)
            {
                if ((scale >= 0.06f) && (scale <= 0.22f))
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
                if ((scale >= 0.54f) && (scale <= 0.71f))
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
