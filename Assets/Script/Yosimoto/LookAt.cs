using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public static LookAt instance;
    private void Start()
    {
        instance = this;
    }
    /*
    LookAt関数を２Dで使えるようにしました.
    さらに動きとテクスチャーの矛盾は解消されました
    さらに追従させることもできます.（ターゲットへの方向を導きだしてからそちらに向かうだけ）
    さらにどれぐらいの速さでターゲットの方向を見るのか、滑らかさなどの設定も可能にしました.(Slerp関数との同時利用を一つにしただけ)
    */

    //注意：授業の暇な時に実装してください：推奨：ライブラリー化することにより別開発プロジェクトでも使えます.
    //ちゃっちゃんにきいたライブラリー化　https://chatgpt.com/share/670a4050-25ec-8000-b1e8-80011beb52d4

    /*
     このコードでできること
    マウスカーソルなどによる誘導弾
    自機を追いかける追撃弾
 
    とにかく！！LookAt関数を２Dで使えるようにした！！moovtowers関数などを使わずに！
     */

    // void LookAt2D(ターゲットポジション,ターゲットの方向により写真を反転の有無,追従の有無,追従スピード,回転速度,滑らかさ)  この順で入力することにより動きます
    public void LookAt2D(Vector2 targetPosition, bool inversion = true, bool pictyer = false, bool move = false, float speed = 1f, float rotationSpeed = 100f, float slerpFactor = 1f)
    {
        int a = 0;
        if (pictyer == true)
        {
            a = 180;
        }
        Vector2 myPosition = (Vector2)transform.position;
        Vector2 direction = targetPosition - myPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(180, a, angle * -1); ;
        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, slerpFactor * Time.deltaTime * rotationSpeed);
        if (inversion)
        {
            if (angle >= 90 || angle <= -90) { transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z); }
            else { transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z); }
        }
        if (move)
        {
            Vector2 moveDirection = direction.normalized;
            Vector2 newPosition = myPosition + moveDirection * speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }


    public GameObject target;
    public float Speed = 10;
    public float roSpeed = 10;
    public float Factorcount = 10;

    void Update()
    {
        //____Lookat2D____例集_____
        //使うときの簡単な考え方として使う引数まではfalseで使う引数のみをtrueにする.

        //LookAt2D(ターゲットポジション, ターゲットの方向により写真を反転の有無, 追従の有無, 追従スピード, 回転速度, 滑らかさ)
        //target.transform.positionに向きます.
        LookAt2D(target.transform.position);
        //targetの位置により画像の向きが変わりま.または変わらない
        LookAt2D(target.transform.position, true);
        LookAt2D(target.transform.position, false);
        //targetの写真の先頭は左向き.または右向き
        LookAt2D(target.transform.position, true, true);
        LookAt2D(target.transform.position, true, false);
        //targetを基準値（1f）で追いかけます.または追いかけないです.
        LookAt2D(target.transform.position, true, true, true);
        LookAt2D(target.transform.position, true, true, false);
        //targetをSpeedで追いかけます.または直書きの値で追いかけます.
        LookAt2D(target.transform.position, true, true, true, Speed);
        LookAt2D(target.transform.position, true, true, true, 10f);
        //回転速度を調整します。または直書き.
        LookAt2D(target.transform.position, true, true, true, Speed, roSpeed);
        LookAt2D(target.transform.position, true, true, true, Speed, 10f);
        //回転における滑らかさを調整します。または直書き.
        LookAt2D(target.transform.position, true, true, true, Speed, roSpeed, Factorcount);
        LookAt2D(target.transform.position, true, true, true, Speed, roSpeed, 10);

        //追いかけないが回転速度を落とす.
        LookAt2D(target.transform.position, true, true, false, 0, 10, 100);
    }
}