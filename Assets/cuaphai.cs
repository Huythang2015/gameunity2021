using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuaphai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cau.instace.cuatrai = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cau.instace.transform.position = cau.instace.khuvucden.position;
        }
    }
}
