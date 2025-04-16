using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientminigame : MonoBehaviour
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
        Vector3 tempc = compass.eulerAngles;
        Vector3 tempn = needle.eulerAngles;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            compassSpin += 0.00005f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            compassSpin -= 0.00005f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            needleSpin += 0.0001f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            needleSpin -= 0.0001f;
        }

        tempc.z += compassSpin;
        tempn.z += needleSpin;

        compassSpin *= 0.9999f;
        needleSpin *= 0.9999f;

        compass.eulerAngles = tempc;
        needle.eulerAngles = tempn;
    }
}
