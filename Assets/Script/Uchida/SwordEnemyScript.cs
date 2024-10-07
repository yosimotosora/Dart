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

        PlayerTransform = Player.transform;
        _ThisTransform = this.transform;
        Vector3 _Vector = (_ThisTransform.position - PlayerTransform.position);
        _ThisTransform.rotation = Quaternion.FromToRotation(Vector3.up, _Vector);

    }//end

    void Move()
    {
    }

}
