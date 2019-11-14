using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatecheck : MonoBehaviour
{
    // Start is called before the first frame update
    public int birdCount;
    private Animator animator;
    bool isDoorClosed;
    void Start()
    {
        animator = GetComponent<Animator>();
        isDoorClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(birdCount==3)
        {
            isDoorClosed = false;
        }
        else
        {
            isDoorClosed = true;
        }
        if (isDoorClosed)
        {
            animator.SetBool("isOpen", false);
        }
        else
        {
            animator.SetBool("isOpen", true);
        }


    }

}
