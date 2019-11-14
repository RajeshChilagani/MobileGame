using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatecheck : MonoBehaviour
{
    // Start is called before the first frame update
    public int birdCount;
    private Animator animator;
    bool isDoorClosed;
    Transform LevelFinish;
    public Canvas canvas;

    void Start()
    {
        LevelFinish = canvas.transform.Find("LEnd");
        LevelFinish.gameObject.active = false;
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
            StartCoroutine("LF");

        }


    }
    IEnumerator LF()
    {
        yield return new WaitForSeconds(2);
        LevelFinish.gameObject.active = true;
    }

}
