using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D enemyRigidBody;
    Vector2 dynamic= new Vector2(0,-1f);
   
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.position += dynamic*2*Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.transform.position.y> enemyRigidBody.position.y)
        {
            dynamic.y = -1f;
        }
        else if(collision.collider.transform.position.y < enemyRigidBody.position.y)
        {
            dynamic.y = 1f;
        }
    }
}
