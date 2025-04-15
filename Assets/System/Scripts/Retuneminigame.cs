using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Retuneminigame : MonoBehaviour
{
    public GameObject p;
    TMP_Text prog;
    public KeyCode curr;
    bool isCompledted;
    float timer;

    KeyCode[] t = { KeyCode.T,KeyCode.H, KeyCode.E,KeyCode.Space,KeyCode.Q,KeyCode.U,KeyCode.I,KeyCode.C,KeyCode.K, KeyCode.Space, KeyCode.B,KeyCode.R, KeyCode.O, KeyCode.W, KeyCode.N, KeyCode.Space, KeyCode.F,KeyCode.O,KeyCode.X, KeyCode.Space, KeyCode.J,KeyCode.U,KeyCode.M,KeyCode.P,KeyCode.E,KeyCode.D, KeyCode.Space, KeyCode.O, KeyCode.V, KeyCode.E, KeyCode.R, KeyCode.Space, KeyCode.T,KeyCode.H, KeyCode.E, KeyCode.Space, KeyCode.L,KeyCode.A,KeyCode.Z,KeyCode.Y, KeyCode.Space, KeyCode.D,KeyCode.O,KeyCode.G, KeyCode.Space};

    string[] l = { "T", "h", "e", " ", "Q", "u", "i", "c", "k", " ", "B", "r", "o", "w", "n", " ", "F", "o", "x", " ", "J", "u", "m", "p", "e", "d", " ", "O", "v", "e", "r", " ", "t", "h", "e", " ", "L", "a", "z", "y", " ", "D", "o", "g", "" };

    string written = "" ;

    public int pos = 0;
    void Start()
    {
        isCompledted = false;
        prog = p.GetComponent<TMP_Text>();
        prog.text = written;
    }

    void Update()
    {
        curr = t[pos];
        if ((Input.anyKeyDown) && (isCompledted == false))
        {
            if (Input.GetKeyDown(t[pos]))
            {
                if(pos < t.Length-1)
                {
                    written += l[pos];
                    if ((pos == 9) || (pos == 19) || (pos == 35))
                    {
                        written += "\n";
                    }
                    prog.text = written;
                    pos++;
                    if (pos == t.Length - 1)
                    {
                        isCompledted = true;
                        timer = Time.time + 2;
                    }
                }
            }
        }
        if ((isCompledted) && (Time.time > timer))
        {
            Destroy(this.gameObject);
        }
    }
}
