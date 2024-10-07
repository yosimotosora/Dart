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
    public float MoveSpeed=10.0f;
    private Vector3 _Vector;
    //private GameObject ChildObject;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        //ChildObject = transform.GetChild(0).gameObject;

        Look();
    }
    void Update()
    {
        
        Move();


    }//end

    void Look()
    {
        PlayerTransform = Player.transform;
        _ThisTransform = this.transform;
        _Vector = (_ThisTransform.position - PlayerTransform.position);
        _ThisTransform.rotation = Quaternion.FromToRotation(Vector3.up, _Vector);
    }
    void Move()
    {
        //var pos = transform.position;
        //pos.x -= MoveSpeed * Time.deltaTime;
        //transform.position = pos;

        //var a = ChildObject.transform.right;
        //this.transform.position-= MoveSpeed * Time.deltaTime * a; 

        transform.Translate(new Vector3(0, -MoveSpeed, 0) * Time.deltaTime);
    }

}
