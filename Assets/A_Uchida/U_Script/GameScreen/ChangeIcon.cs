using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIcon : MonoBehaviour
{

    public SpriteRenderer[] IconRenderer;
    //{汗,ケチャップ,カビ,コーヒーの順番で}


    void Start()
    {

        IconRenderer[0].enabled = true;
        IconRenderer[1].enabled = false;
        IconRenderer[2].enabled = false;
        IconRenderer[3].enabled = false;

        IconRenderer[0] = IconRenderer[0].GetComponent<SpriteRenderer>();
        IconRenderer[1] = IconRenderer[1].GetComponent<SpriteRenderer>();
        IconRenderer[2] = IconRenderer[2].GetComponent<SpriteRenderer>();
        IconRenderer[3] = IconRenderer[3].GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //

        if (Input.GetKeyDown(KeyCode.Z))//汗
        {
            IconRenderer[0].enabled=true;
            IconRenderer[1].enabled=false;
            IconRenderer[2].enabled=false;
            IconRenderer[3].enabled=false;
        }
        if (Input.GetKeyDown(KeyCode.X))//ケチャップ
        {
            IconRenderer[0].enabled = false;
            IconRenderer[1].enabled = true;
            IconRenderer[2].enabled = false;
            IconRenderer[3].enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.C))//カビ
        {
            IconRenderer[0].enabled = false;
            IconRenderer[1].enabled = false;
            IconRenderer[2].enabled = true;
            IconRenderer[3].enabled = false;

        }
        if (Input.GetKeyDown(KeyCode.V))//コーヒー
        {
            IconRenderer[0].enabled = false;
            IconRenderer[1].enabled = false;
            IconRenderer[2].enabled = false;
            IconRenderer[3].enabled = true;
        }

        //

    }


}
