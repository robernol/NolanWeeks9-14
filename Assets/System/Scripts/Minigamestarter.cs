using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class minigamestarter : MonoBehaviour
{
    bool canActivate;
    public GameObject game, cam, p;
    public GameObject t;
    void Start()
    {
        canActivate = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (canActivate == true) && (t == null))
        {
            Vector3 temp = cam.transform.position;
            temp.z = -2;
            temp.y -= 0.2f;
            t = Instantiate(game, temp, transform.rotation);
            p.GetComponent<NewBehaviourScript>().canMove = false;
        }
        if ((t == null) && canActivate == true)
        {
            p.GetComponent<NewBehaviourScript>().canMove = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canActivate = true;  
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canActivate = false;
    }
}
