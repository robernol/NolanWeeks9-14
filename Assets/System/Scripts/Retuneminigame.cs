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
    //I couldn't think of a better way to do this in time but hey it works!
    KeyCode[] t = { KeyCode.T,KeyCode.H, KeyCode.E,KeyCode.Space,KeyCode.Q,KeyCode.U,KeyCode.I,KeyCode.C,KeyCode.K, KeyCode.Space, KeyCode.B,KeyCode.R, KeyCode.O, KeyCode.W, KeyCode.N, KeyCode.Space, KeyCode.F,KeyCode.O,KeyCode.X, KeyCode.Space, KeyCode.J,KeyCode.U,KeyCode.M,KeyCode.P,KeyCode.E,KeyCode.D, KeyCode.Space, KeyCode.O, KeyCode.V, KeyCode.E, KeyCode.R, KeyCode.Space, KeyCode.T,KeyCode.H, KeyCode.E, KeyCode.Space, KeyCode.L,KeyCode.A,KeyCode.Z,KeyCode.Y, KeyCode.Space, KeyCode.D,KeyCode.O,KeyCode.G, KeyCode.Space};
        //arrays of every keycode you need to hit and the letter in string it correspons to on the screen
    string[] l = { "T", "h", "e", " ", "Q", "u", "i", "c", "k", " ", "B", "r", "o", "w", "n", " ", "F", "o", "x", " ", "J", "u", "m", "p", "e", "d", " ", "O", "v", "e", "r", " ", "t", "h", "e", " ", "L", "a", "z", "y", " ", "D", "o", "g", "" };

    string written = "" ; //start at nothing

    public int pos = 0; //position is therefore at 0
    void Start()
    {
        isCompledted = false;
        prog = p.GetComponent<TMP_Text>();
        prog.text = written; //progressively writes the words you type in red over the black letters
    }

    void Update()
    {
        curr = t[pos]; //I think I did this just to see if it worked
        if ((Input.anyKeyDown) && (isCompledted == false)) //if you press a key and the game is not yet finished,
        {
            if (Input.GetKeyDown(t[pos])) //checks if the input was the correct keycode
            {
                if(pos < t.Length-1)
                {
                    written += l[pos]; //if so, adds the corresponding letter up on screen
                    if ((pos == 9) || (pos == 19) || (pos == 35)) //at these specific points, adds a break so the unfinished word doesn't come up on the previous line
                    {
                        written += "\n";
                    }
                    prog.text = written; //updates the text
                    pos++;
                    if (pos == t.Length - 1) //moves to the next index number, if it has reached the end, game is completed and timer is started
                    {
                        isCompledted = true;
                        timer = Time.time + 2;
                    }
                }
            }
        }
        if ((isCompledted) && (Time.time > timer)) //after the timer has elapsed, object destroys itself
        {
            Destroy(this.gameObject);
        }
    }
}
