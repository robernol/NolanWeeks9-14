using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class minigamestarter : MonoBehaviour
{
    bool canActivate;
    public bool isActive;
    public GameObject game, cam, p, indicator, alien;
    public GameObject t;
    void Start()
    {
        canActivate = false;
    }

    void Update()
    {
        if (isActive)
        {
            indicator.SetActive(true);
        }

        if ((Input.GetKeyDown(KeyCode.E)) && (canActivate == true) && (t == null) && (isActive == true))
        {
            isActive = false;
            Vector3 temp = cam.transform.position;
            temp.z = -2;
            temp.y -= 0.2f;
            t = Instantiate(game, temp, transform.rotation);
            p.GetComponent<NewBehaviourScript>().canMove = false;
        }

        if ((isActive == false) && (canActivate == true) && (indicator.activeSelf))
        {
            indicator.SetActive(false);
            alien.GetComponent<Alien>().taskCompleted = true;
            alien.GetComponent<Alien>().dialogue.text = "Finally. Now get back over here.";
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
