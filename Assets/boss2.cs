using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : MonoBehaviour
{
    public float PlayerVsViTriBanDau;
    public Vector2 viTribandau;
    public Animator anim;
    public Vector2 diemDuoi;
    public float KhoangCachSeDuoi = 3;
    bool a = true;
    int tocDo = 3;
    float tgcho = 0;
    public float mau = 100;
    public static boss2 instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        

        viTribandau = transform.position;
    }

    // Update is called once per frame
    void Update()    
    {
        // xoayboss
        if (transform.position.x < Player.Instance.transform.position.x)
        {
            Vector2 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
        else
        {
            Vector2 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
       
        diemDuoi = new Vector2(Player.Instance.transform.position.x, transform.position.y);
        PlayerVsViTriBanDau = Vector2.Distance(viTribandau,Player.Instance.transform.position);
        float KhoangCachVsPlayer = Vector2.Distance(transform.position, Player.Instance.transform.position);
        
       
        if (KhoangCachVsPlayer >= KhoangCachSeDuoi && PlayerVsViTriBanDau < 20)
        {
            duoi(5);
            Debug.Log(1);
          
        }
        else if (KhoangCachVsPlayer < KhoangCachSeDuoi && PlayerVsViTriBanDau < 20) // danh
        {
            anim.SetBool("di", false);
            anim.SetBool("dung", true);


            tgcho += Time.deltaTime;
            if (tgcho >= 3)
            {
                danh();
                Debug.Log(7);
                tgcho = 0;
            }
        }
        else if (PlayerVsViTriBanDau >= 20)// ve tri tri ban dau
        {
            ve();

        }
        if (mau < 0)
        {
            // chet hay cai gi day
        }
    }
    void duoi(int tocdo)
    {
        anim.SetBool("di", true);
        anim.SetBool("dung", false);
        anim.SetBool("tancong", false);
        transform.position = Vector2.MoveTowards (transform.position, diemDuoi, tocDo * Time.deltaTime);

    }
    void ve()
    {
        transform.position = Vector2.MoveTowards(transform.position, viTribandau,tocDo * Time.deltaTime);
        Debug.Log("ve");
    }
    void danh()
    {
        
        
            anim.SetBool("di", false);
            anim.SetBool("dung", false);
            anim.SetBool("tancong", true);
      
    }
    public void satthuong(int dam)
    {
        mau -= dam;
        Debug.Log(dam);
    }

}
