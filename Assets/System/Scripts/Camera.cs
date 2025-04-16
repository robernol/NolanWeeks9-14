using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool alienTalking, isSleeping;

    public GameObject player;
    public GameObject alien;
    public GameObject bed;
    void Start()
    {
        alienTalking = false; //originally was gonna have camera move to alien when talking to him, but meh. Maybe later
        isSleeping = false; //camera focuses on bed when sleeping
    }

    void Update()
    {
        Vector3 temp = transform.position;

        if ((alienTalking == false) && (isSleeping == false)) //if neither talking to alien nor sleeping, camera follows player
        {
            temp.x = player.transform.position.x;
            temp.y = player.transform.position.y;
        }
        else if (alienTalking == true) //if true, focuses on alien
        {
            temp.x = alien.transform.position.x;
            temp.y= alien.transform.position.y;
        }
        else if (isSleeping == true) //if true, focuses on bed
        {
            temp.x = bed.transform.position.x;
            temp.y = bed.transform.position.y;
        }

        transform.position = temp;
    }
}
