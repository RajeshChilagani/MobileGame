﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D playerRigidBody;
    Vector2 oldposition, newposition;
    public Animator animator;
    AudioSource audioSource;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        transform.position = GameObject.Find("playerstartPosition").transform.position;
        newposition = transform.position;
        audioSource=GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.loop = true;
            audioSource.volume = 0.3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
      
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.tag.Equals("move"))
                {
                   newposition = hit.collider.transform.position;
                }
            }
        }
        playerRigidBody.position = Vector2.MoveTowards(playerRigidBody.position, newposition, Time.deltaTime*2);
        if(playerRigidBody.position==newposition)
        {
            animator.SetBool("ismoving", false);
        }
        else
        {
            animator.SetBool("ismoving", true);
        }
    }
}
