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
    public float Timer = 0.0f;//
    public float Interval_ase = 0.0f;//汗の玉のインターバル
    public float Interval_ketyappu = 0.0f;//ケチャップの玉のインターバル
    public float Interval_kabi=0.0f;//カビの玉のインターバル
    public GameObject BulletPrefab_ase;
    public GameObject BulletPrefab_ketyappu;
    public Transform ShotPoint;
    public Transform ShotPoint_ketyappu;
    public int ChangeScore=0;//変身切り替え
    private Animator animatormae;
    Vector3 beforemousePos;
    public static float Interval_kabi_Kari = 0.0f;
    public Spear_Attack spear_attack;
    public float Timer_Spear;//Spear_Attackに移すための変数
    // Start is called before the first frame update
    void Start()
    {
        animatormae = GetComponent<Animator>();//アニメーション
       
    }
    // Update is called once per frame

    void Update()
    {
       Timer_Spear = spear_attack.Timer_Spear;
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
              if (ChangeScore ==2 && Timer >= Interval_kabi)//カビ
              {
                if (ChangeScore == 2 && Timer_Spear >= Timer)
                {
                
                }
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

