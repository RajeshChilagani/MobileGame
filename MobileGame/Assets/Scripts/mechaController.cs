﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaController : MonoBehaviour
{

    public bool isBirdInCage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void withChildMecha()
    {
        if (gameObject.tag == "MechaRotatingPlatform")
        {
            //rotate clockwise

            gameObject.transform.Rotate(new Vector3(0, 0, 90));
                
            
        }
        else if (gameObject.tag == "MechaTV")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
                //stop blowing steam
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    public void withoutChildMecha()
    {
        Debug.Log("Start");
        if (gameObject.tag == "MechaRotatingPlatform")
        {
            //rotate anticlockwise
            gameObject.transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (gameObject.tag == "MechaTV")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
                
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
                //start blowing steam
                Debug.Log("start blowing steam");
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
