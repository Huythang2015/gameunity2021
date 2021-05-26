using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gachroi : MonoBehaviour
{
    public float time = 2;
    bool cham = false;
    public Rigidbody2D rigigach;
    public Collider2D coligach;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.tag == "Player")
        {
            rigigach.gravityScale = 0.3f;
            Debug.Log(coli.name);
        }
    }
    
}
