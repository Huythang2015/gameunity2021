using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bansung : MonoBehaviour
{
    
    Animator atorbansung;
    float thidanh = 1;
    Rigidbody2D rigibansung;
    float tg;
    float tocdoduoi =1.5f;
    float phamViDuoi = 10 ;
    Vector3 vitribandau;
    BoxCollider2D boxcoli;
    bool quaytrai = true;
    float tgcho = 0;
    // Start is called before the first frame update
    void Start()
    {
        vitribandau = transform.position;
        atorbansung = GetComponent<Animator>();
        rigibansung = GetComponent<Rigidbody2D>();
        boxcoli = gameObject.GetComponent<BoxCollider2D>();
        boxcoli.enabled = true;    
    }

    // Update is called once per frame
    void Update()
    {   // quay dung huong player
        Vector2 scalebansung = transform.localScale;
        if (Player.Instance.transform.position.x > transform.position.x && quaytrai )
        {
            scalebansung.x *= -1;
            transform.localScale = scalebansung;
            quaytrai = false;
        }
        else if (Player.Instance.transform.position.x < transform.position.x && quaytrai == false)
        {
            scalebansung.x *= -1;
            transform.localScale = scalebansung;
            quaytrai = true;
        }
        float khoangcachve = Vector2.Distance(vitribandau,Player.Instance.transform.position); /*đo khoảng cách giữa 
        vị trí gốc của quái vs player*/

        float khoangcachduoi = Vector2.Distance(Player.Instance.transform.position, transform.position); // khoảng cách giữa hai thằng player và quái
        tgcho = tgcho + Time.deltaTime;

        if (khoangcachduoi <= thidanh && khoangcachve < phamViDuoi)// khoảng cách mà nhỏ hơn float thidanh thì ta đánh
        {
            Debug.Log(tgcho);
          
            if (tgcho >= 5)
            {
                danh(); // hàm chứa việc đánh
                tgcho = 0;
                Debug.Log("danh");
            }
             
            else if (tgcho >= 1.5)
            {
                danh();
            }
            else if (tgcho < 1.5)
            {
                dung();
            } 
        }


        if (khoangcachduoi > thidanh && khoangcachve < phamViDuoi) // player ở gần thì đuổi
        {
            atorbansung.SetBool("dung", false);
            atorbansung.SetBool("danh", false);
            tg -= Time.deltaTime;

            if (tg < 0) //duoi theo player
            {
                Vector2 vitriXplayer = new Vector2(Player.Instance.transform.position.x, transform.position.y);
                transform.position = Vector3.MoveTowards(transform.position,vitriXplayer , tocdoduoi * Time.deltaTime);
                Debug.Log("duoi");
                atorbansung.SetBool("di", true);

            } 
        }
        if (khoangcachve > phamViDuoi) // player đi xa thì về
        {
            transform.position = Vector3.MoveTowards(transform.position, vitribandau, tocdoduoi * Time.deltaTime);
            atorbansung.SetBool("dung", false);
            atorbansung.SetBool("di", true);
        }
        if (transform.position == vitribandau)
        {
            atorbansung.SetBool("dung", true);
            atorbansung.SetBool("di", false);
        }

    }
    private void danh()
    {
        atorbansung.SetBool("danh", true);
        atorbansung.SetBool("di", false);
        atorbansung.SetBool("dung", false);
       
    }
    void dung()
    {
        atorbansung.SetBool("danh", false);
        atorbansung.SetBool("di", false);
        atorbansung.SetBool("dung", true);
    }
}

