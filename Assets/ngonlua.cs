using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ngonlua : MonoBehaviour
{
    public float tgTonTai = 3;
    public float tocdo = 10;
    public Transform boss;
    public float DoDairay;
    public LayerMask layer;
    bool BanPhai;
    public Rigidbody2D rg;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("xoaBo", tgTonTai);
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        if (Player.Instance.transform.position.x > boss.position.x)
        {
            rg.velocity = transform.right * tocdo;
            BanPhai = true;
        }
        else if (Player.Instance.transform.position.x < boss.position.x)
        {
            BanPhai = false;
            rg.velocity = -transform.right * tocdo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //sat thuong vien dan
        
        if (BanPhai == true)
        {
           // transform.Translate(transform.right * tocdo * Time.deltaTime);
           
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, DoDairay, layer);
                if (hit.collider != null)
            {
                xoaBo();
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("sat111111");
                    Player.Instance.matMau(10);
                }
            }
        }
        else if (BanPhai == false)
        {
            //transform.Translate(transform.right * -1 * tocdo * Time.deltaTime);
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * -1, DoDairay, layer);
            if (hit.collider != null)
            {
                xoaBo();
                if (hit.collider.CompareTag("Player"))
                {
                   
                    Player.Instance.matMau(10);
                }
            }
        }

            
    }
    void xoaBo()
    {
        Destroy(gameObject);
    }
}
