using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyScript : MonoBehaviour
{

    /*プレイヤーをタグで管理したいのと、複製したプレハブにpublicでドラック＆ドロップ
     する方法ができない？気がするからprivateで済ませてる*/
    private GameObject Player;
    private Transform PlayerTransform;
    //自分のTransform
    private Transform _ThisTransform;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Move();

        /*
         吉本そらに相談：プレイヤーに回転が向くように設定したつもりが90°のずれ
        があるので、剣エネミーの画像を90°回転させた状態で用意したい
         */
        PlayerTransform = Player.transform;
        _ThisTransform = this.transform;
        Vector3 _Vector = (_ThisTransform.position - PlayerTransform.position);
        _ThisTransform.rotation = Quaternion.FromToRotation(Vector3.up, _Vector);

    }//end

    void Move()
    {
    }

}
