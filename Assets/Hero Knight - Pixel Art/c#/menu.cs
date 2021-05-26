using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    bool boMeNu = false;
    public GameObject meNu;
    // Start is called before the first frame update
    void Start()
    {
        meNu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            boMeNu = !boMeNu;
        }
        if (boMeNu == true)
        {
            meNu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            meNu.SetActive(false);
            Time.timeScale = 1;
        }
     }
    public void trolai()
    {
        boMeNu = false;
        
    }
}
