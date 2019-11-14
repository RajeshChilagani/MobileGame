using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaController : MonoBehaviour
{
    
    public bool startAnimation;
    public bool isBirdInCage;
    private Sprite tvSprite;
    Animator animator;
    AudioSource audioSource;
    GameObject UIObject;

    // Start is called before the first frame update
    void Start()
    {
        UIObject = GameObject.FindGameObjectWithTag("UITag");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
       
        if (animator)
        {
            animator.SetBool("isTurnedOn", startAnimation);
            animator.SetBool("TvOn", startAnimation);
        }
        if(audioSource)
        {
            audioSource.loop = true;

        }
        
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
                if (animator)
                {
                    startAnimation = true;
                    audioSource.Play();
                    animator.SetBool("TvOn", startAnimation);
                }
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
                //stop blowing steam
                if(animator)
                {
                    startAnimation = true;
                    audioSource.Play();
                    animator.SetBool("isTurnedOn", startAnimation);
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
                if (animator)
                {
                    startAnimation = false;
                    audioSource.Stop();
                    animator.SetBool("TvOn", startAnimation);
                }
            }
        }
        else if (gameObject.tag == "MechaBoiler")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject.GetComponent<Collider2D>());
                //start blowing steam
                if(animator)
                {
                    startAnimation = false;
                    audioSource.Stop();
                    animator.SetBool("isTurnedOn", startAnimation);
                }
               
                Debug.Log("start blowing steam");
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
