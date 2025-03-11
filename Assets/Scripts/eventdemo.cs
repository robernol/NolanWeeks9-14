using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventdemo : MonoBehaviour
{
    public GameObject imag;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ButtonIsPUSH()
    {
        Debug.Log("button is PUSH");
    }

    public void ButtonIsPushed()
    {
        Debug.Log("button is push");
    }

    public void ButtonIsEnter()
    {
        Debug.Log("button is enter");
        imag.transform.localScale *= 1.1f;
    }

    public void ButtonIsExit()
    {
        Debug.Log("smile :)");
        imag.transform.localScale = new Vector3 (1, 1, 1);
    }

}
