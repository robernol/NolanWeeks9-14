using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giantStep : MonoBehaviour
{
    public knight k;
    public ParticleSystem part;
    public Camera cam;
    public AnimationCurve shake;
    bool isInTheAir;
    float timer;
    void Start()
    {
        timer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = cam.transform.position;

        if (timer - Time.time > 0)
        {
            temp.y += (shake.Evaluate(timer - Time.time)) * 0.8f;
        }
        else
        {
            temp = transform.position;
            temp.y += 2;
            temp.z = -10;
        }
        cam.transform.position = temp;

        if ((k.isJumping != isInTheAir) && (isInTheAir == true))
        {
            timer = Time.time + 0.3f;
            ParticleSystem s = Instantiate(part);
            s.transform.position = transform.position;
            s.Play();
        }
        isInTheAir = k.isJumping;
    }

    public void makeCameraShake()
    {
        timer = Time.time + 0.3f;
        ParticleSystem s = Instantiate(part);
        s.transform.position = transform.position;
        s.Play();
    }
}
