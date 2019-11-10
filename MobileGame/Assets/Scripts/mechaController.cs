using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaController : MonoBehaviour
{
    private bool isMechaEnabled = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(gameObject.name == "RotatingPlatform")
        {
            if (isMechaEnabled && Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D,Vector2.zero);

                
                    if (hit.collider != null && hit.transform.name == "RotatingPlatform")
                    {
                        Debug.Log("My object is clicked by mouse");
                        transform.Rotate(new Vector3(0, 0, 90));
                    }
            }
        }
        else if(gameObject.name == "TV")
        {
            if (isMechaEnabled && Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
        else if (gameObject.name == "Boiler")
        {
            if (isMechaEnabled && Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
    }

    public void switchMechaAbility()
    {
        isMechaEnabled = !isMechaEnabled;
        Debug.Log(isMechaEnabled);
    }
}
