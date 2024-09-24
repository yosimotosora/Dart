using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.AI;


public class Player_main : MonoBehaviour
{
    [SerializeField] float speed;
    public float MoveSpeed = 5.0f;//スピード
    public Vector3 Offset = Vector3.zero;
    public static float timer = 0.0f;
    public float Interval_ase = 0.0f;//汗の玉のインターバル
    public float Interval_ketyappu = 0.0f;//ケチャップの玉のインターバル
    public static float Interval_kabi = 0.0f;//カビの玉のインターバル
    public GameObject BulletPrefab_ase;
    public GameObject BulletPrefab_ketyappu;
    public Transform ShotPoint;
    public Transform ShotPoint_ketyappu;
    public int ChangeScore=0;//変身切り替え
    private Animator animatormae;

    Vector3 beforemousePos;

    // Start is called before the first frame update
    void Start()
    {
        animatormae = GetComponent<Animator>();//アニメーション
    }
    public IEnumerator ase()
    {
        yield return new WaitForSeconds(Interval_ase);
    }
    public IEnumerator ketyappu()
    {
        yield return new WaitForSeconds(Interval_ketyappu);
    }
    // Update is called once per frame

    void Update()
    {

        Move();
        Change();
        Shooting();
    }
    void Move()//移動
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition + Offset;
            mousePos.z = 10.0f;
            beforemousePos= Camera.main.ScreenToWorldPoint(mousePos);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition + Offset;
            mousePos.z = 10.0f;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
            //カメラを基準としてposの位置
            Vector3 vec=pos - beforemousePos;
            transform.position+=vec;
            beforemousePos= pos;

            //timer+= Time.deltaTime;
            //if ( timer >= Interval)
            //{
            //    GameObject obj = Instantiate(BulletPrefab, ShotPoint.position, ShotPoint.rotation);
            //    //タイマーをリセット
            //    timer = 0.0f;
            //}
        }

}
    void Shooting()
    {
        if (Input.GetMouseButton(0))
        {

            timer += Time.deltaTime;
          if (ChangeScore==0&&timer>=Interval_ase)//汗
          {
                GameObject obj = Instantiate(BulletPrefab_ase, ShotPoint.position, ShotPoint.rotation);
                //タイマーリセット
                timer = 0;
          }
            if (ChangeScore == 1&&timer>=Interval_ketyappu)//ケチャップ
            {
                GameObject obj = Instantiate(BulletPrefab_ketyappu, ShotPoint_ketyappu.position, ShotPoint_ketyappu.rotation);
                //タイマーリセット
                timer = 0;
            }
              if (ChangeScore ==2 && timer >= Interval_ketyappu)//カビ
              {
                
              }
              if (ChangeScore == 2 && timer <= Interval_ketyappu)//カビ
              {
                
              }
        }
    }
    void Change()
    {
        if (Input.GetKeyDown(KeyCode.Z))//汗
        {
         ChangeScore = 0;
        }
        if (Input.GetKeyDown(KeyCode.X))//ケチャップ
        {
         ChangeScore = 1;
        }
        if (Input.GetKeyDown(KeyCode.C))//カビ
        {
            ChangeScore = 2;

        }
    }
    void OnWillRenderObject()
    {
    if (Camera.current.name!="SceneCamera"&&Camera.current.name!="Preview Camera")
        {
            //Move();
        } 
    }
    private void OnCollisionEnter(Collision other)
    {

    }
}

