using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaController : MonoBehaviour
{

    public bool isBirdInCage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void withChildMecha()
    {
        if (gameObject.tag == "MechaRotatingPlatform")
        {
            /* if (Input.GetMouseButtonDown(0))
             {
                 Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                 Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
                 RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


                 if (hit.collider != null && hit.collider.tag == "Mecha")
                 {
                     Debug.Log("My object is clicked by mouse");
                     hit.transform.Rotate(new Vector3(0, 0, 90));
                 }
             }*/

            //rotate clockwise

            gameObject.transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (gameObject.tag == "MechaTV")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
    }
    public void withoutChildMecha()
    {
        if (gameObject.tag == "MechaRotatingPlatform")
        {
            /* if (Input.GetMouseButtonDown(0))
             {
                 Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                 Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
                 RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


                 if (hit.collider != null && hit.collider.tag == "Mecha")
                 {
                     Debug.Log("My object is clicked by mouse");
                     hit.transform.Rotate(new Vector3(0, 0, 90));
                 }
             }*/

            //rotate anticlockwise

            gameObject.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (gameObject.tag == "MechaTV")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
    }
}
