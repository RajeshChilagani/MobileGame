using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCheck : MonoBehaviour
{
    public GameObject cagedBirdObject;

    private int lives = 2;
    private int raycastDistance = 10;
    private GameObject playerGameObject;

    void Start()
    {
        playerGameObject = GameObject.Find("Player");
    }
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero,touchPosition,Color.red);
            //check for touch input
            if ((touchPosition.x > transform.position.x - 1.3 && touchPosition.x < transform.position.x + 1.3) && (touchPosition.y > transform.position.y - 1.3 && touchPosition.y < transform.position.y + 1.3))
            {
                // Cast a ray straight on all four directions
                RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance);
                RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance);
                RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance);
                RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, raycastDistance);

                // If it hits player while touching...
                if ((hitDown.collider != null && hitDown.collider.gameObject.tag == "Player") || (hitUp.collider != null && hitUp.collider.gameObject.tag == "Player") ||
                    (hitLeft.collider != null && hitLeft.collider.gameObject.tag == "Player") || (hitRight.collider != null && hitRight.collider.gameObject.tag == "Player"))
                {
                    lives--;
                }

            }
            if (lives == 0)
            {
                playerGameObject.GetComponent<PlayerManager>().birdsCollected++;
                Destroy(gameObject);
                Destroy(cagedBirdObject);
            }
        }
    }
}
