using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class debugminigame : MonoBehaviour
{
    public GameObject b;
    public GameObject box;
    public GameObject parent;
    int totalBugs;
    public int squishedBugs;
    float w, h;
    float timer;
    bool bugsRemaining;
    void Start()
    {
        bugsRemaining = true; //keeps track if game is completed
        totalBugs = 20; //spawns 20 bugs to begin with
        squishedBugs = 0;
        w = (box.GetComponent<SpriteRenderer>().bounds.size.x) /2.5f; //boundary for where the bugs spawn in
        h = (box.GetComponent<SpriteRenderer>().bounds.size.y) /2.5f;
        for (int i = 0; i < totalBugs; i++) //summons 20 bugs at random positions and rotations
        {
            float x = transform.position.x +(Random.Range(-w, w));
            float y = transform.position.y + (Random.Range(-h, h));
            Vector3 temp = new Vector3(x, y, -3);
            Vector3 rand = new Vector3 (0, 0, 0);
            rand.z = Random.Range(0f, 360f);
            GameObject t;
            t = Instantiate(b, temp, Quaternion.Euler(rand)); //instantiates bug
            t.GetComponent<bug>().origin = this; //lets that prefab know who the boss is
        }
    }

    void Update()
    {
        if (squishedBugs >= 20) //if adequate bugs squished and game not already completed
        {
            if (bugsRemaining)
            {
                timer = Time.time + 2; //sets timer
                bugsRemaining = false; //game complete
            }
            if (Time.time > timer) //after timer, object destroys itself
            {
                Destroy(parent);
            }

        }
    }
}
