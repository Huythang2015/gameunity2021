using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cau : MonoBehaviour
{
    public static cau instace;
    public Vector2 vitribandau;
    public Transform khuvucden;
    public bool cuatrai;
    bool caudi;
    float time = 3;
    private void Awake()
    {
        instace = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        vitribandau = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
        
           
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {

            Debug.Log(cuatrai);
            if (cuatrai == true)
            {
                dichuyensangphai();
            }
            else
            {
                dichuyensangtrai();
            }
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        caudi = false;
    }

    void dichuyensangphai()
    {
         Vector2 diemden = new Vector2(khuvucden.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, diemden, 3 * Time.deltaTime);
    }
    void dichuyensangtrai()
    {
        transform.position = Vector2.MoveTowards(transform.position, vitribandau, 3 * Time.deltaTime);
    }

}
