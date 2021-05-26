using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satthuong : MonoBehaviour
{
    public Transform vitriDanh;
    public float phamVidanh = 0.5f;
    public LayerMask layePlayer;
    public Collider2D noiChiuSatThuong;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void danh()
    {
         
        //tao khu vuc kiem tra va cham
        Collider2D[] enemy = Physics2D.OverlapCircleAll(vitriDanh.position, phamVidanh, layePlayer);
        // phat hien va cham
        foreach (Collider2D col in enemy) //neu player co trong mang enemy thi moi goi ham ben trong no
        {
            Debug.Log(col.name);
            if (col==noiChiuSatThuong)
            {
                Debug.Log(col.name);
                Player.Instance.GetComponent<Player>().matMau(10);
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (vitriDanh == null)
            return;
        Gizmos.DrawWireSphere(vitriDanh.position, phamVidanh);
    }
}
