using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D enemyRigidBody;
    Vector2 maxTopPosition, maxBottomPosition;
    bool movingTop;
    bool movingBottom;
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        maxTopPosition = enemyRigidBody.position + new Vector2(0, 2);
        maxBottomPosition = enemyRigidBody.position + new Vector2(0, -2);
        movingTop = true;
        movingBottom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingTop)
        {
            enemyRigidBody.position = Vector2.MoveTowards(enemyRigidBody.position, maxTopPosition, Time.deltaTime * 2);
        }
        else if (movingBottom)
        {
            enemyRigidBody.position = Vector2.MoveTowards(enemyRigidBody.position, maxBottomPosition, Time.deltaTime * 2);
        }
        if (enemyRigidBody.position.y >= maxTopPosition.y)
        {
            movingTop = false;
            movingBottom = true;
        }
        else if (enemyRigidBody.position.y <= maxBottomPosition.y)
        {
            movingTop = true;
            movingBottom = false;
        }

    }
}
