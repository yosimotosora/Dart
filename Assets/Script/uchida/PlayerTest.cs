using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * 3.0f * transform.right;
        }
        if(Input.GetKey(KeyCode.A))
        transform.position -= Time.deltaTime *3.0f*transform.right;
    }
}
