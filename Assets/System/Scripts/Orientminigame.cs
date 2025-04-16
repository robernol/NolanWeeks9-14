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

        Vector3 temp = compass.eulerAngles;
        temp.z = Random.Range(30.0f, 330.0f);
        compass.eulerAngles = temp;

        temp = needle.eulerAngles;
        temp.z = Random.Range(30.0f, 330.0f);
        needle.eulerAngles = temp;
    }

    void Update()
    {
        if (completed == false)
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

            if (compassSpin > 0.1)
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

            tempc.z += compassSpin + (needleSpin/10);
            tempn.z += needleSpin + (compassSpin/2);

            compassSpin *= 0.9999f;
            needleSpin *= 0.9999f;

            compass.eulerAngles = tempc;
            needle.eulerAngles = tempn;
        }
        else
        {
            if (Time.time > timer)
            {
                Destroy(this.gameObject);
            }
        }

        if (((needle.eulerAngles.z >= 350) || (needle.eulerAngles.z <= 10)) && completed == false)
        {
            if ((compass.eulerAngles.z >= 350) || (compass.eulerAngles.z <= 10))
            {
                completed = true;
                timer = Time.time + 2;
            }
        }
    }
}
