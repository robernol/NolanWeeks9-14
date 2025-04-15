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
        alienTalking = false;
        isSleeping = false;
    }

    void Update()
    {
        Vector3 temp = transform.position;

        if ((alienTalking == false) && (isSleeping == false))
        {
            temp.x = player.transform.position.x;
            temp.y = player.transform.position.y;
        }
        else if (alienTalking == true)
        {
            temp.x = alien.transform.position.x;
            temp.y= alien.transform.position.y;
        }
        else if (isSleeping == true)
        {
            temp.x = bed.transform.position.x;
            temp.y = bed.transform.position.y;
        }

        transform.position = temp;
    }
}
