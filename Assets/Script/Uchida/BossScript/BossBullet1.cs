using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossBullet1 : MonoBehaviour
{

    public float MoveSpeed = 6.0f;//弾の移動速度
    public float DestroyTimer=0;
    public float DestroyTime = 4.0f;//このオブジェクトが消滅する時間


    void Start()
    {
        
    }
    public void Update()
    {

        DestroyTimer += Time.deltaTime;//タイマーの設定

        transform.position -= MoveSpeed * Time.deltaTime * transform.right;
        if (DestroyTimer >= DestroyTime)
        {
            Destroy(gameObject);
        }
        
    }


}
