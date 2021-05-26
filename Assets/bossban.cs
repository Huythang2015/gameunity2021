using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossban : MonoBehaviour
{
    public Transform diemBan;
    public GameObject dan;
    public float tgbatdau =3;
    public float tgban = 3;
    public static bossban instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void ban1()
    {
       // if (tgban <= 0)
        //{

            {
                Instantiate(dan, transform.position, diemBan.rotation);
                tgban = tgbatdau;
            }
       // }
       // else
        //{
           // tgban -= Time.deltaTime;
        //}
    }
}
