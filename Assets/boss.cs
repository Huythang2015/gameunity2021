using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public Transform chaBoss;
    bool quaytrai;
    Vector3 scale;
    public Animator ani;
    float tgcho = 0;
    public Transform diemSatThuong;
    public float phamvi = 3;
    public Collider2D noiChiuSatThuong;
    public bool ban = false;
    public static boss Instance;
    Transform viTriBanDau;
    public float tocDo;
    
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        viTriBanDau = transform;
        
    }

    // Update is called once per frameif
    void Update()
    {
        Debug.Log(quaytrai);
        float a = Random.Range(1, 3);
        // xu ly quay lai vitriBanDau
        if (transform.position.x <= 63)
        {
            
        }
        



        if (Player.Instance.transform.position.x < chaBoss.position.x && quaytrai == true)
        {
            //XOAY BOSS
            scale = chaBoss.localScale;
            scale.x = scale.x * -1;
            quaytrai = false;
            chaBoss.localScale = scale;
            Debug.Log("quaytrai");
        }
        else if (Player.Instance.transform.position.x > chaBoss.position.x && quaytrai == false) 
        {
            scale = chaBoss.localScale;
            scale.x = scale.x * -1;
            
            chaBoss.localScale = scale;
            quaytrai = true;
            Debug.Log("quayphai");
        }
        // khoang cach de tan cong
        float khoangcach = Vector2.Distance(Player.Instance.transform.position, transform.position);
        if (khoangcach <= 6)
        {
            ani.SetBool("di", false);
            ani.SetBool("dung", true);
            tgcho += Time.deltaTime;

            if (a == 1 || a==2)
            {
                if (tgcho >= 0.5)
                {
                    ban = true;
                    ani.SetBool("tancong", true);
                    ani.SetBool("di", false);
                    ani.SetBool("dung", false);
                    if (tgcho >= 5)
                    {
                        ban = false;
                        ani.SetBool("tancong", false);
                        ani.SetBool("di", false);
                        ani.SetBool("dung", true);
                        tgcho = 0;
                    }
                }
            }




            else
            {
                if (tgcho >= 2)
                {
                    ban = true;
                    ani.SetBool("tancong", true);
                    ani.SetBool("di", false);
                    ani.SetBool("dung", false);
                    if (tgcho >= 5)
                    {
                        ban = false;
                        ani.SetBool("tancong", false);
                        ani.SetBool("di", false);
                        ani.SetBool("dung", true);
                        tgcho = 0;
                    }
                }

            }
        }
        else if (khoangcach > 6){
            ani.SetBool("tancong", false);
            ani.SetBool("di", true);
            ban = false;
        }
    }
    // Sát thương khi boss mổ
    public void satthuong()
    {
        Collider2D[] coliboss = Physics2D.OverlapCircleAll(diemSatThuong.position, phamvi);
        foreach(Collider2D coli in coliboss)
        {
            if (coli == noiChiuSatThuong)
            {
                Debug.Log(coli.name);
                Player.Instance.GetComponent<Player>().matMau(10);
            }
        }
    }
    // hien thi thuc te cai ray
    private void OnDrawGizmosSelected()
    {
        if (diemSatThuong == null)
            return;
        Gizmos.DrawWireSphere(diemSatThuong.position, phamvi);
    }
}
