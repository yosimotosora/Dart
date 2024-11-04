using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Animation : MonoBehaviour
{
    public float timer = 0.0f;
    public float Life_Time = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        if(timer > Life_Time)
        {
            Destroy(gameObject);
        }

    }
}
