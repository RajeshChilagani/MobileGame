using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class EnemyRange : MonoBehaviour
{
    public Canvas canvas;
    Transform UIB;
    Transform UIT;
    // Start is called before the first frame update
    void Start()
    {
        UIB = canvas.transform.Find("Button");
        UIT = canvas.transform.Find("GameOver");
        UIB.gameObject.active = false;
        UIT.gameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.GetChild(0).name = "remove";
            collision.gameObject.transform.GetChild(0).parent = null;
            UIB.gameObject.active = true;
            UIT.gameObject.active = true;
            Destroy(collision.gameObject);
        }
    }
 
}
