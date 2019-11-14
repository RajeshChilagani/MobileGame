using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCheckFinal : MonoBehaviour
{

    private int lives = 1;
    private int raycastDistance = 10;
    private new Collider2D collider;
    public GateController gateConroller;
    public UI uiScript;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < Input.touchCount; i++)
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


            if (hit.collider != null && hit.collider.tag == "FinalCage" && gameObject.transform.name == hit.collider.name)
            {
                Debug.Log(collider.bounds.extents.y);

                RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - collider.bounds.extents.y - 1), Vector2.up, raycastDistance);
                RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x + collider.bounds.extents.x + 0.5f, gameObject.transform.position.y), Vector2.right, raycastDistance);
                RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x - collider.bounds.extents.x - 0.5f, gameObject.transform.position.y), Vector2.left, raycastDistance);
                RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + collider.bounds.extents.y + 1), Vector2.down, raycastDistance);



                Debug.Log(hitDown.collider.gameObject.tag);
                Debug.Log(hitLeft.collider.gameObject.tag);
                Debug.Log(hitRight.collider.gameObject.tag);
                Debug.Log(hitUp.collider.gameObject.tag);

                // If it hits player while touching...
                if ((hitDown.collider != null && hitDown.collider.tag == "Player") || (hitUp.collider != null && hitUp.collider.tag == "Player") ||
                   (hitLeft.collider != null && hitLeft.collider.tag == "Player") || (hitRight.collider != null && hitRight.collider.tag == "Player"))
                {
                    //Debug.Log("test");
                    lives--;
                }

                if (lives == 0)
                {
                    GameObject childBirdObject = gameObject.transform.GetChild(0).gameObject;
                    if (childBirdObject.activeSelf)
                    {
                        
                        childBirdObject.SetActive(false);
                        gateConroller.birdInCage--;
                        Debug.Log("birds in cage :" + gateConroller.birdInCage);
                        if (gateConroller.isDoorClosed == false && gateConroller.birdInCage < 3)
                        {
                            gateConroller.GateClose();
                        }
                    }
                    else
                    {
                        childBirdObject.SetActive(true);
                        gateConroller.birdInCage++;
                        Debug.Log("birds in cage :" + gateConroller.birdInCage);
                        if (gateConroller.birdInCage == 3)
                        {
                            gateConroller.GateOpen();
                        }
                    }

                    lives = 1;


                }
            }
        }
    }

}
