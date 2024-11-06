using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyscript : MonoBehaviour
{

    private float UpDownSpeed = 4.0f;
    private float YUp=4.0f;
    private float YDown=-4.0f;
    private bool UpDownBool;

    private float MoveSpeed=3.0f;

    //BoolÇ™trueÇæÇ¡ÇΩÇÁè„Ç…Ç¢Ç≠ÅBfalseÇæÇ¡ÇΩÇÁâ∫Ç…Ç¢Ç≠ÅB

    void Start()
    {
        UpDownBool = false;
    }
    void Update()
    {
        var Thisposition = transform.position;
        if (Thisposition.y <= YDown)
            UpDownBool = true;
        if (Thisposition.y >= YUp)
            UpDownBool = false;
        UpDown();

        transform.position -= Time.deltaTime * MoveSpeed * transform.right;

    }

    void UpDown()
    {
        var position = transform.position;
        if (UpDownBool == true)
        {
            position.y += UpDownSpeed*MoveSpeed*Time.deltaTime;
            this.transform.position = position;
        }
        if (UpDownBool == false)
        {
            position.y -= UpDownSpeed * MoveSpeed * Time.deltaTime;
            this.transform.position = position;
        }

    }//end
}
