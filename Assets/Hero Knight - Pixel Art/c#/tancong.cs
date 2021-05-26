using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tancong : MonoBehaviour
{
    public static tancong tc;
    public Transform chem1;
    public float pvdanh;
    public LayerMask enemyLayer  ;
    public bool playerchem  ;
    public float timedanh;
    private void Awake()
    {
        tc = this;
    }
    void start()
    {
        timedanh = 0;
       
    }
    private void Update()
    {
        
    }
    public void chem()
    {
        
        Collider2D[] diemdanh = Physics2D.OverlapCircleAll(chem1.position, pvdanh,enemyLayer );
       
        foreach ( Collider2D enemy  in diemdanh  )
        {
            if (enemy.tag == "enemy" || enemy.tag == "Boss")
            {
                Debug.Log("chemchung");


                boss2.instance.satthuong(10);
                
            }
            
        }
    
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(chem1.position, pvdanh);
    }


}
