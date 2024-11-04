using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyScript : MonoBehaviour
{
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
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += anglespeed * Time.deltaTime;//角度を更新
        offsetY = Mathf.Sin(angle);//角度を使ってSin波を取得（比例）
        pos.y = offsetY * distance;//Sin波（比率）に距離をかけてY座標を決定
        pos += moveVec * Time.deltaTime;//移動量を座標に適用
        transform.position = pos + startPos;//transformにposを代入

    }
}
