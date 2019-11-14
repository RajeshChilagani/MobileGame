using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startposition;
    public GameObject player;
    public Canvas canvas;
    Transform UIB;
    Transform UIT;
    public int birdCount;
    public List<Image> birds;
    int UIBirds = 4;
    public bool noMoreBirds;
    public int maxBirdCount;
    
    void Start()
    {
        birdCount = 0;
        UIB = canvas.transform.Find("Button");
        UIT = canvas.transform.Find("GameOver");
        UIB.gameObject.active = false;
        UIT.gameObject.active = false;
        noMoreBirds = true;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("birdcount is" + birdCount);
        int i = birdCount;
        while(i>0)
        {
            birds[i-1].color = Color.white;
            i--;
        }
        int j = UIBirds;
        while (j> birdCount)
        {
            birds[j - 1].color = Color.black;
            j--;
        }
       
          
    }
   public void restart()
    {

        Instantiate(player,startposition.transform.position,Quaternion.identity);
        Destroy(GameObject.Find("remove"));
        UIB.gameObject.active = false;
        UIT.gameObject.active = false;
    }

    public void OnGui()
    {
        if (!noMoreBirds)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Cannot Add more birds" +
                "");
        }
    }
}
