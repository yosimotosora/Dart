using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player_main : MonoBehaviour
{
    [SerializeField] float speed;
    public float MoveSpeed = 5.0f;//スピード
    public Vector3 Offset = Vector3.zero;
    public float Timer = 0.0f;//
    public float Interval_ase = 0.0f;//汗の玉のインターバル
    public float Interval_ketyappu = 0.0f;//ケチャップの玉のインターバル
    public float Interval_kabi=0.0f;//カビの玉のインターバル
    public float Interval_coffee;
    public GameObject BulletPrefab_ase;
    public GameObject BulletPrefab_ketyappu;
    public GameObject Spear;
    public Transform ShotPoint;
    public Transform ShotPoint_ketyappu;
    public Transform ShotPoint_Spear;
    public int ChangeScore=0;//変身切り替え
    private Animator animatormae;
    Vector3 beforemousePos;
    public Vector2 moveAreaLimit = new(8.0f, 4.5f);
    public static float Interval_kabi_Kari = 0.0f;
    public float Timer_Spear;//Spear_Attackに移すための変数
    public static bool MoveFlag=true;
    [SerializeField]


    void Start()
    {
        animatormae = GetComponent<Animator>();//アニメーション
        GameManager.gamePlaing();

    }
    // Update is called once per frame

    void Update()
    {
        //Timer_Spear = spear_attack.Timer_Spear;
        if (MoveFlag) 
       {
        Move();    
        Shooting();
        Change();
       }
        MoveAreaCheck();
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

            Timer += Time.deltaTime;
          if (ChangeScore==0&&Timer>=Interval_ase)//汗
          {
                GameObject obj = Instantiate(BulletPrefab_ase, ShotPoint.position, ShotPoint.rotation);
                //タイマーリセット
                Timer = 0;
          }
            if (ChangeScore == 1&&Timer>=Interval_ketyappu)//ケチャップ
            {
                GameObject obj = Instantiate(BulletPrefab_ketyappu, ShotPoint_ketyappu.position, ShotPoint_ketyappu.rotation);
                //タイマーリセット
                Timer = 0;
            }
              if(ChangeScore == 2 && Timer >= Interval_kabi)
            {
                GameObject obj = Instantiate(Spear, ShotPoint_Spear.position, ShotPoint_Spear.rotation);
                 //タイマーリセット
                Timer = 0;
            }
              if (ChangeScore ==3 && Timer >= Interval_coffee)//コーヒ
              {
                 
              }
        }
          else if (!Input.GetMouseButton(0))
          {
                Timer = 0;
          }
    }
    void Change()
    {
        if (Input.GetKeyDown(KeyCode.Z))//汗
        {
            ChangeScore= 0;
        }
        if (Input.GetKeyDown(KeyCode.X))//ケチャップ
        {
            ChangeScore= 1;
        }
        if (Input.GetKeyDown(KeyCode.C))//カビ
        {
            ChangeScore = 2;

        }
        if (Input.GetKeyDown(KeyCode.V))//コーヒー
        {
            ChangeScore = 3;
        }
    }
    void MoveAreaCheck()
    {
        Vector3 pos = transform.position;
        if (pos.x > moveAreaLimit.x) 
        {
            pos.x = moveAreaLimit.x;
            MoveFlag = false;
        }
        if (pos.x < -moveAreaLimit.x)
        {
            pos.x = -moveAreaLimit.x;
            MoveFlag = false;
        }
        if (pos.y > moveAreaLimit.y)
        {
            pos.y = moveAreaLimit.y;
            MoveFlag = false;
        }
        if (pos.y < -moveAreaLimit.y)
        {
            pos.y = -moveAreaLimit.y;
            MoveFlag = false;
        }
        else 
        { 
            MoveFlag = true;
        }
        transform.position = pos;
    }
    public static void SetMoveFlag(bool flag)
    {
        MoveFlag= flag;
    }
}

