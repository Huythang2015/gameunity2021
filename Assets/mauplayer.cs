using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mauplayer : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setmaxheat(float mau)
    {
        slider.maxValue = mau;
        slider.value = mau;
    }
    public void setheath (float mau)
    {
        slider.value = mau;
    }
}
