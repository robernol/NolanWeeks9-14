using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientminigame : MonoBehaviour //vestigial script from when I tried to rename it, I am too scared to delete it.
{
    public GameObject c, n;
    Transform compass, needle;
    float compassSpin, needleSpin;
    void Start()
    {
        compass = c.GetComponent<Transform>();
        needle = n.GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 tempc = compass.eulerAngles; //spinning "velocity" for the compass and needle
        Vector3 tempn = needle.eulerAngles;

        if (Input.GetKey(KeyCode.UpArrow)) //up and down rotates the compass counterclockwise and clockwise respectively
        {
            compassSpin += 0.00005f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            compassSpin -= 0.00005f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //left and right does the same for the needle
        {
            needleSpin += 0.0001f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            needleSpin -= 0.0001f;
        }

        tempc.z += compassSpin; //adds "velocity" to the z rotation
        tempn.z += needleSpin;

        compassSpin *= 0.9999f; //very slippery
        needleSpin *= 0.9999f;  //not much friction at all really

        compass.eulerAngles = tempc;
        needle.eulerAngles = tempn;
    }
}
