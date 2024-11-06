using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    public float MoveSpeed = 6.0f;
    private float DestroyTimer=0;
    private float DestroyTime=4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        DestroyTimer += Time.deltaTime;
        transform.position -= Time.deltaTime * MoveSpeed * transform.right;

        if (DestroyTimer >= DestroyTime)
        {
            Destroy(gameObject);
        }

    }

    void OnCollieionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);

        }

    }

}
