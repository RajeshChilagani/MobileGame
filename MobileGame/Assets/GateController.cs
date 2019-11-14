using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator animator;
    private bool isDoorOpen = false;
    public int birdInCage;
    public bool isDoorClosed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isDoorClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GateOpen()
    {
        animator.SetBool("isOpen", true);
    }

    public void GateClose()
    {
        animator.SetBool("isOpen", false);
    }
}
