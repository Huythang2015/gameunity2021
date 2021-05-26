using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour // Player
{ // khai bao hoat hoa, rigibody, toa do nhan vat
    public static Player Instance; // Singletone
    public Animator aninhanvat;
    public Rigidbody2D rigi;
    public float tocdo;
    bool quayphai;
    Vector3 Scale;
    public bool chamdat;
    public float lucnhay;
    public tancong tancong;
    float tgChem = 1;
    bool chem; 

    //MÁu
    public float mauToiDa = 100;
    public float mau ;
 

    float time = 0f; 
    bool nhay = false;
    public Collider2D col1;
    public Collider2D col2;
    public mauplayer mauplayer;
    private void Awake()
    {
        Instance = this; // Singletone
      
    }
    // Start is called before the first frame update
    void Start()
    {
        chamdat = true;
        quayphai = true;
        chem = false;
        mauplayer.setmaxheat(mauToiDa);
        mau = mauToiDa;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (mau <= 0 ) // su ly mau (hp)
        {
            chet(); // goi ham chet
        }
        Scale = transform.localScale;

        if (Input.GetKey(KeyCode.Z)) //di sang phai
        {
            transform.Translate(tocdo * -1 * Time.deltaTime, 0, 0);
            aninhanvat.SetBool("chay", true);// cho bien toc do truc x cua doi tuong gan vao bien float "speed" trong animator
            if (quayphai == true)
            {
                Scale.x = -Mathf.Abs(Scale.x);
                transform.localScale = Scale;
                quayphai = false;
                rigi.MovePosition(new Vector2(1, 0));
               
            }
        }


        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.C)) // di sang trai
        {
            transform.Translate(tocdo * 1 * Time.deltaTime, 0, 0);
            aninhanvat.SetBool("chay", true);
            if (quayphai == false)
            {
                quayphai = true;
                Scale.x = Mathf.Abs(Scale.x);
                transform.localScale = Scale;
              
            }
        }

        else
        {

            aninhanvat.SetBool("chay", false);
        }
        if (Input.GetKeyDown(KeyCode.S) && chamdat == true && nhay == false) // nhay len
        {
            rigi.AddForce(Vector2.up * lucnhay);
            chamdat = false;
            aninhanvat.SetBool("nhay", true);
            nhay = true;
        }

        else if (nhay == true && Input.GetKeyDown (KeyCode.S))
        {
            rigi.AddForce(Vector2.up * lucnhay);
            nhay = false;
            
        }
        {
             
        }
        if (Input.GetKeyUp(KeyCode.X))//su ly chém
        {
            aninhanvat.SetBool("chem", true);
            
            tancong.chem();

        }
        else
        {
            aninhanvat.SetBool("chem", false);
            //  tancong.colichem.enabled = true;


        }
       
        // phần sử lý chết khi rơi tự do quá lâu
       /* if (transform.position.y < -30)
        {
            loadman();
        }
        */
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == col1)
        {

        }
        if (collision == col2)
        {

        }
        if (collision.tag == "KVdanh")
        {
            Debug.Log("hit from monster");
        }
        if (collision.tag == "dat" || collision.tag == "nuoc")
        {
            aninhanvat.SetBool("nhay", false);
            chamdat = true;

        }
        if (collision.tag == "quaman")
        {
            sangman();
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "dat")
        {
            aninhanvat.SetBool("nhay", false);
            chamdat = true;
            Debug.Log(collision.tag);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "dat")
        {
            aninhanvat.SetBool("nhay", true);
            chamdat = false;
            Debug.Log(collision.tag);

        }
    }
  
    public void chet()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        aninhanvat.SetBool("chet", true);
    }
    void loadman()//load man hien tai
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void sangman()// sang man tiep theo
    {
        SceneManager.LoadScene(1);
    }
    // SAT THUONG PLAYER
    public void matMau(float satthuong)
    {
        mau -= satthuong;
        
        mauplayer.setheath(mau);
    }
}

