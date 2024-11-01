using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    private float MoveSpeed = 6.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position -= Time.deltaTime * MoveSpeed * transform.right;


    }

    void OnCollieionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);

        }

    }

}
