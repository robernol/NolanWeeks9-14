using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer - Time.time < 0)
        {
            Destroy(gameObject);
        }
    }
}
