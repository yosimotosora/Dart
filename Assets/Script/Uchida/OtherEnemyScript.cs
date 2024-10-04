using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherEnemyScript : MonoBehaviour
{
    public float MoveSpeed=3.0f;

    void Start()
    {
        
    }
    void Update()
    {
        Move();

    }
    void Move()
    {
        this.transform.position -= MoveSpeed * Time.deltaTime * transform.right;
        Vector2 MyTransform = this.transform.position;
        if (MyTransform.y >= 3.5f)
            transform.position -= MoveSpeed * Time.deltaTime * transform.up;
        if (MyTransform.y <= -3.5f)
            transform.position += MoveSpeed * Time.deltaTime * transform.up;
    }

}//end
