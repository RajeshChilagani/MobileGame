using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 position;
    float velocity = 3f;
    Rigidbody2D playerRigidBody;
    Vector2 oldposition, newposition;
    bool ismoving;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerRigidBody.position = newposition;
        ismoving = false;

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
                if (hit.collider)
                {
                   newposition = hit.collider.transform.position;
                }
            }
        }
        playerRigidBody.position = Vector2.Lerp(playerRigidBody.position, newposition, Time.deltaTime*2);
       
    }
}
