using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 position;
    Rigidbody2D playerRigidBody;
    Vector2 oldposition, newposition;
    public Animator animator;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerRigidBody.position = newposition;

    }

    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetMouseButtonDown(0))
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
