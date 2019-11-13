using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaController : MonoBehaviour
{
   
    public bool startAnimation;
    public bool isBirdInCage;
    private Sprite tvSprite;
    Animator Boiler;
    // Start is called before the first frame update
    void Start()
    {
        Boiler = GetComponent<Animator>();
        if(Boiler)
        Boiler.SetBool("isTurnedOn", startAnimation);
        Boiler.SetBool("TvOn", startAnimation);
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void withChildMecha()
    {
        if (gameObject.tag == "MechaRotatingPlatform")
        {
            //rotate clockwise
            gameObject.transform.Rotate(new Vector3(0, 0, -90));       
            
        }
        else if (gameObject.tag == "MechaTV")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Boiler)
                {
                    startAnimation = true;
                    Boiler.SetBool("TvOn", startAnimation);
                }
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
                //stop blowing steam
                if(Boiler)
                {
                    startAnimation = true;
                    Boiler.SetBool("isTurnedOn", startAnimation);
                }
               
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public void withoutChildMecha()//bird is not in cage
    {
        Debug.Log("Start");
        if (gameObject.tag == "MechaRotatingPlatform")
        {
            //rotate anticlockwise
            gameObject.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (gameObject.tag == "MechaTV")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Boiler)
                {
                    startAnimation = false;
                    Boiler.SetBool("TvOn", startAnimation);
                }
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
                //start blowing steam
                if(Boiler)
                {
                    startAnimation = false;
                    Boiler.SetBool("isTurnedOn", startAnimation);
                }
               
                Debug.Log("start blowing steam");
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
