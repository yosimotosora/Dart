using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{

    public GameObject FinishBeam;
    private GameObject Player;//タグで判定する

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        
    }

    void Shot()
    {


       /* if (Input.GetKeyDown(KeyCode.Return)){
            Instantiate(Beam, ShotPoint.transform.position, ShotPoint.transform.rotation);
        }
       *///プレイヤースクリプト用

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            //衝突したオブジェクトの位置にコーヒーが弾けてるイラストを作る
            Instantiate(FinishBeam, collision.gameObject.transform.position, Quaternion.identity);
            //プレイヤーの子オブジェクトにする(イラストの動きとプレイヤーの動きは連動させたいので)
            FinishBeam.transform.parent = Player.transform;
        }
    }

}
