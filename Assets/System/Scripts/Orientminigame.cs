using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject c, n;
    Transform compass, needle;
    float compassSpin, needleSpin;
    bool completed = false;
    float timer;
    void Start()
    {
        compass = c.GetComponent<Transform>();
        needle = n.GetComponent<Transform>();

        Vector3 temp = compass.eulerAngles; //sets the compass at a random rotation not too close to where it should be
        temp.z = Random.Range(30.0f, 330.0f);
        compass.eulerAngles = temp;

        temp = needle.eulerAngles;
        temp.z = Random.Range(30.0f, 330.0f); //same for the needle
        needle.eulerAngles = temp;
    }

    void Update()
    {
        if (completed == false)
        {
            Vector3 tempc = compass.eulerAngles;    //spinning "velocity" for the compass and needle
            Vector3 tempn = needle.eulerAngles;

            if (Input.GetKey(KeyCode.UpArrow))  //up and down rotates the compass counterclockwise and clockwise respectively, but also affects the needle a bit
            {
                compassSpin += 0.00005f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                compassSpin -= 0.00005f;
            }

            if (Input.GetKey(KeyCode.LeftArrow)) //left and right does the same for the needle, also affects the compass a bit
            {
                needleSpin += 0.0001f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                needleSpin -= 0.0001f;
            }

            if (compassSpin > 0.1) //max speeds so doesn't get out of hand
            {
                compassSpin = 0.1f;
            }
            if (compassSpin < -0.1)
            {
                compassSpin = -0.1f;
            }

            if (needleSpin > 0.15)
            {
                needleSpin = 0.15f;
            }
            if (needleSpin < -0.15)
            {
                needleSpin = -0.15f;
            }

            tempc.z += compassSpin + (needleSpin/10); //adds "velocity" to the z rotation
            tempn.z += needleSpin + (compassSpin/2);

            compassSpin *= 0.9999f; //very slippery
            needleSpin *= 0.9999f;  //not much friction at all really

            compass.eulerAngles = tempc;
            needle.eulerAngles = tempn;
        }
        else
        {
            if (Time.time > timer) //after completed and two seconds passed, destroys itself
            {
                Destroy(this.gameObject);
            }
        }

        if (((needle.eulerAngles.z >= 350) || (needle.eulerAngles.z <= 10)) && completed == false) //if not already completed and line up the compass and needle well enough, win
        {
            if ((compass.eulerAngles.z >= 350) || (compass.eulerAngles.z <= 10)) //has a 10 degree margin of error on either side
            {
                completed = true; //game completed, timer starts
                timer = Time.time + 2;
            }
        }
    }
}
