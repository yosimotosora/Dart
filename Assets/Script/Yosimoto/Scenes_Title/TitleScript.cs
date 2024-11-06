using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TitleScript : MonoBehaviour
{
    public GameObject gool;
    public float start;//自分の位置
    private bool moveFlg;//移動しているか確認
    public float t;//イージンクに使う変数
    public float distanceago = 0.0f;
    public float dist = 0.0f;
    public float Speed = 0.0f;
    public float Nameraka = 0.5f;//最初のPleyreSpeedの割合
    public static bool Flag = true;


    public bool MoveFlag=true;
    public Vector3 moveVec = Vector3.zero;//移動スピード
    public Vector3 pos = Vector3.zero;//計算した座標を保存する変数
    public Vector3 startPos;//生成された座標を保存する変数

    public float angle = 0.0f;//Sin波用の角度
    public float offsetY = 0.0f;//Y軸をずらす量

    public float anglespeed = 0.0f;//角度の速さ 上下の
    public float distance = 1.0f;//Y軸の移動量　上下の幅
    // Start is called before the first frame update
    void Start()                    
    {
        Flag = true;
        MoveFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag == true)
        {
            if(MoveFlag == true)
            {
                distanceago = gool.transform.position.y - transform.position.y;//goolのｙの座標と自分のオブジェクトのｙ
                if (distanceago * distanceago >= 1 && moveFlg == false)
                {
                    t = 0;
                    moveFlg = true;
                    start = transform.position.y;

                }
            MoveUpdate();
            }
            if (MoveFlag==false)
            {
                angle += anglespeed * Time.deltaTime;//角度を更新
                offsetY = Mathf.Sin(angle);//角度を使ってSin波を取得（比例）
                pos.y = offsetY * distance;//Sin波（比率）に距離をかけてY座標を決定
                pos += moveVec * Time.deltaTime;//移動量を座標に適用
                transform.position = pos + startPos;//transformにposを代入
            }
        }
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
            MoveFlag = false;
            startPos = transform.position;
        }
        float a = Easing.BackOut(t, 1, 0, 1, 1);

        float iti = a * dist;
        transform.position = (new Vector2(transform.position.x, start + iti));
    }
    public static void SetMoveFlag(bool flag)
    {
        Flag = flag;
    }
}
