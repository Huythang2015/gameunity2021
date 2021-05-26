using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tet : MonoBehaviour
{
    public BoxCollider2D A;
    float tg = 0;
    private void Start()
    {
        A.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && tg <= 0)
        {
            A.enabled = true;
            tg = 2;
        }
        if (tg > 0)
        {
            tg =- Time.deltaTime;
            A.enabled = false;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.name == "A")
        {
            Debug.Log("cham");
        }
    }
}
