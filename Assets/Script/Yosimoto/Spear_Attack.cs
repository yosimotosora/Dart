using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class Spear_Attack : MonoBehaviour
{
    public float Interval_kabi = Player_main.Interval_kabi_Kari;
    public float timer;//=Player_main.Timer_Kari;
    public Player_main player_main;
    public int ChangeScore = 0;//変身切り替え
    private Animator animatormae;
    [SerializeField] private Renderer Spear;
    public float Timer_Spear;//槍がアニメーションしはじめらタイマー開始のための変数
    public float Interval_Spear;//槍が攻撃し始めてからのInterval
    // Start is called before the first frame update
    void Start()
    {
        animatormae = GetComponent<Animator>();//アニメーション
    }
    // Update is called once per frame
    void Update()
    {
        timer = player_main.Timer;
        ChangeScore=player_main.ChangeScore;
        Interval_kabi=player_main.Interval_kabi;

            
        //Change();
        Attack();

    }

    void Attack()//槍攻撃
    {
        if (ChangeScore == 2)
        {
          if(Interval_kabi< timer&&ChangeScore==2)//槍が攻撃する時
          {
            animatormae.SetBool("Spear", true);
            Spear.enabled=true;//画像切り替え
            Timer_Spear+= Time.deltaTime;
                
          }
            if (Interval_kabi >= timer && ChangeScore == 2)
            {
                Spear.enabled = false;
                animatormae.SetBool("Spear", false);
            }
          if (ChangeScore == 2 && Timer_Spear >= Interval_Spear)//槍が攻撃し始めてから攻撃終了までの計測　
          {
                animatormae.SetBool("Spear", false);
                Spear.enabled = false;
                player_main.Timer = 0;
                Timer_Spear =0;
          }
          //  else if (Interval_kabi >= timer&& ChangeScore == 2)//槍が攻撃しない時
          //{
          //  animatormae.SetBool("Spear", false);
          //  Spear.enabled=false;
          //}
           else if (!Input.GetMouseButton(0))
            {
                animatormae.SetBool("Spear", false);
                if (Timer_Spear >= 0)
                {
                    Timer_Spear = 0;
                }
            }
        }
        else
        {
            Spear.enabled = false;
            animatormae.SetBool("Spear", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
