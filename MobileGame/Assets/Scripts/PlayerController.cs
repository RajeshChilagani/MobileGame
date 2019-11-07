using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 position;
    float horizontal;
    float vertical;
    float velocity = 3f;
    void Start()
    {
        position = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal>0 || horizontal<0)
        {
            moveHorizontal();
        }
       else if(vertical>0 || vertical< 0)
        {
            moveVertical();
        }
        
        transform.position = position;

    }
   void moveHorizontal()
    {
        position.x = position.x + velocity * horizontal * Time.deltaTime;
    }
    void moveVertical()
    {
        position.y = position.y + velocity * vertical * Time.deltaTime;
    }
}
