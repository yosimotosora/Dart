using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherEnemyScript : MonoBehaviour
{
    public float MoveSpeed=3.0f;
    public float UpDownSpeed = 5.0f;
    private bool UpDownBool = false;//false‚¾‚Æ‰º‚És‚­

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
            UpDownBool = false;
        if(MyTransform.y <= -3.5f)
            UpDownBool=true;
        if (UpDownBool==false)
            transform.position -= UpDownSpeed * Time.deltaTime * transform.up;
        if (UpDownBool==true)
            transform.position += UpDownSpeed * Time.deltaTime * transform.up;
    }

}//end
