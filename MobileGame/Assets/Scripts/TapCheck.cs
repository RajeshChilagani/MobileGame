using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCheck : MonoBehaviour
{
    public GameObject cagedBirdObject;

    private int lives = 2;
    private int raycastDistance = 10;
    private GameObject playerGameObject;
    public GameObject connectedMechanism;
    private Collider2D collider;

    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        collider = gameObject.GetComponent<Collider2D>();
    }
    void Update()
    {
        
        //for (int i = 0; i < Input.touchCount; i++)
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "cage")
            {
                Debug.Log("hit cage");
                //ContactFilter2D filter = new ContactFilter2D();
                // Cast a ray straight on all four directions
                RaycastHit2D hitDown = Physics2D.Raycast(new Vector2 (transform.position.x, transform.position.y + collider.bounds.extents.y) , Vector2.down, raycastDistance);
                RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - collider.bounds.extents.x, transform.position.y), Vector2.left, raycastDistance);
                RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + collider.bounds.extents.x, transform.position.y), Vector2.right, raycastDistance);
                RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - collider.bounds.extents.y), Vector2.up, raycastDistance);

                Debug.Log(hitDown.collider.tag);
                Debug.Log(hitUp.collider.tag);
                Debug.Log(hitLeft.collider.tag);
                Debug.Log(hitRight.collider.tag);

                // If it hits player while touching...
                if ((hitDown.collider != null && hitDown.collider.tag == "Player") || (hitUp.collider != null && hitUp.collider.tag == "Player") ||
                   (hitLeft.collider != null && hitLeft.collider.tag == "Player") || (hitRight.collider != null && hitRight.collider.tag == "Player"))
                {
                    Debug.Log("test");
                   lives--;
                }

                
                if (lives == 0)
                {
                    // playerGameObject.GetComponent<PlayerManager>().birdsCollected++;
                    mechaController MC = connectedMechanism.GetComponent<mechaController>();
                    MC.switchMechaAbility();
                    Debug.Log("switched");
                    //bird collected
                    Destroy(gameObject);
                    Destroy(cagedBirdObject);
                    lives = 1;
                }
            }
        }
    }
}
