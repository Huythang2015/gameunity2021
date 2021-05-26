using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmanhai : MonoBehaviour
{
    public static bossmanhai instance;
    Vector2 scaleHienTai;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector2 vitribandau = transform.position;   
    }
    
    // Update is called once per frame
    void Update()
    { // xoay boss theo player
      if (Player.Instance.transform.position.x < transform.position.x)
        {
            scaleHienTai = transform.localScale;
            scaleHienTai.x = 1;
            transform.localScale = scaleHienTai;
        }
        else if (Player.Instance.transform.position.x > transform.position.x)
        {
            scaleHienTai = transform.localScale;
            scaleHienTai.x = -1;
            transform.localScale = scaleHienTai;
        }
    }
}
