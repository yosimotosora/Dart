using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Title : MonoBehaviour
{
    public GameObject gool;
    public float start;//自分の位置
    private bool moveFlg;//移動しているか確認
    public float t;//イージンクに使う変数
    public float distance = 0.0f;
    public float dist = 0.0f;
    public float Speed = 0.0f;
    public float Nameraka = 0.5f;//最初のPleyreSpeedの割合
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = gool.transform.position.y - transform.position.y;//goolのｙの座標と自分のオブジェクトのｙ
        if (distance * distance >= 1 && moveFlg == false)
        {
            t = 0;
            moveFlg = true;
            start = transform.position.y;

        }
        MoveUpdate();
    }
    void MoveUpdate()
    {
        if (!moveFlg)
            return;

        dist = gool.transform.position.y - start;//player_mainのｙの座標ー最初の位置で距離をだす
        t += Time.deltaTime * Speed * Nameraka;//毎秒更新　
        //if (t >= 0.2f)
        //{
        //    t += Time.deltaTime * Speed;
        //}
        if (t <= 0.4f)
        {
            t += Time.deltaTime * Speed * Nameraka;
        }
        if (t >= 1)
        {
            t = 1;
            moveFlg = false;
        }
        float a = Easing.BackOut(t, 1, 0, 1, 1);

        float iti = a * dist;
        transform.position = (new Vector2(transform.position.x, start + iti));
    }
}
