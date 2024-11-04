using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject goal;//目的地(コンポーネント)を設定する(プレイヤー)
    public float distance;//プレイヤーと敵の距離を格納する変数
    Vector3 mousePos, pos;
    public float MoveSpeed = 5.0f;//スピード
    public Vector3 Offset = Vector3.zero;
    [Range(0f,0.25f)]
    public float interpolationRatio=0.1f;
    private Animator animatorusiro;
    private Animator animatormae;//アニメーション切り替え
    float tortal_x = 0.0f;//アニメーション管理
    float tortal_y = 0.0f;//アニメーション管理
    public Slider HPSlider;//体力バー
    public float Invincible_Time = 0.0f;
    public float Invincible_Interval = 3.0f;
    public static float HP = 5;
    public bool HPFlag=true;
    public static bool MoveFlag = true;

    void Start()
    {
        //goal = GameObject.Find("plare");//ここで目的地を取得
        animatormae = GetComponent<Animator>();
        animatorusiro = GetComponent<Animator>();

    }
    void Update()
    {
        if (MoveFlag ==true)
        {
            if (Input.GetMouseButtonDown(0))//押したら
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))//押し続けたら
            {
                ////mousePos = Input.mousePosition;
                ////Debug.Log(mousePos);

               //pos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y))+Offset;
                //pos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-mousePos;
                ////pos.z = 0;
                //transform.position +=pos;
                ////transform.position.z = 0;
                //mousePos = pos;
                ////transform.position = Vector3.MoveTowards(transform.position, pos, MoveSpeed * Time.deltaTime);
            }
            distance = Vector2.Distance(transform.position, goal.transform.position+Offset);
             Debug.Log(distance);
            transform.position=Vector3.Lerp(transform.position,goal.transform.position, interpolationRatio);
            //このオブジェクトがこのオブジェクト(goal)に対してこの速さで移動する。
            Change();//変身 アニメーション切替
            if (HPFlag == false)
            {
                Invincible_Time += Time.deltaTime;
                 if(Invincible_Time>=Invincible_Interval )
                 { 
                   HPFlag = true;
                    Invincible_Time = 0;
                 }
            }//無敵時間
            HPstrets(HPSlider, HP);
            if (HP == 0)
            {
                GameManager.GameOvered();
            }
        }
    }
    void Change()//変身
    {
        if (Input.GetKeyDown(KeyCode.Z))//汗
        {
            tortal_x = 1;
            tortal_y = 0;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
        if (Input.GetKeyDown(KeyCode.X))//ケチャップ
        {
            tortal_x = 1;
            tortal_y = 1;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
        if (Input.GetKeyDown(KeyCode.C))//カビ
        {
            tortal_x = 1;
            tortal_y = -1;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
        if (Input.GetKeyDown(KeyCode.V))//カビ
        {
            tortal_x = 0;
            tortal_y = 1;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
    }
    void HPstrets(Slider HPSlider,float hp)
    {
        HPSlider.value = hp;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Enemy")
        {
            if (HPFlag == true)
            {
               HP--; 
               HPFlag = false;              
            }            
        }
    }
    public static void SetMoveFlag(bool flag)
    {
        MoveFlag = flag;
    }
}