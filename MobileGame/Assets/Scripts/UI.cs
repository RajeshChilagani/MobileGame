using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startposition;
    public GameObject player;
    public Canvas canvas;
    public int birdCount;
    void Start()
    {
        birdCount = 0;
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void restart()
    {

        Instantiate(player,startposition.transform.position,Quaternion.identity);
        Destroy(GameObject.Find("remove"));
        canvas.enabled = false;

    }
}
