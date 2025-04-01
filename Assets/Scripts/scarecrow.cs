using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scarecrow : MonoBehaviour
{
    public AnimationCurve fall;
    float timer;
    bool ded;
    void Start()
    {
        timer = -5;
        ded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ded == true)
        {
            Vector3 temp = transform.eulerAngles;
            temp.z = fall.Evaluate(3 - (timer - Time.time));
            transform.eulerAngles = temp;
        }
    }

    void OnCollisionEnter2D (Collision2D hit)
    {
        if (ded == false)
        {
            Debug.Log("Yowch!");
            timer = Time.time + 3;
            ded = true;
        }
    }
}
