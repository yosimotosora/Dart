using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Attack : MonoBehaviour
{
    public float Interval_kabi = Player_main.Interval_kabi_Kari;
    public float timer;//=Player_main.Timer_Kari;
    public Player_main player_main;
    public int ChangeScore = 0;//変身切り替え
    private Animator animatormae;
    [SerializeField] private Renderer Spear;
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
    //void Change()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))//汗
    //    {
    //        ChangeScore = 0;
    //    }
    //    if (Input.GetKeyDown(KeyCode.X))//ケチャップ
    //    {
    //        ChangeScore = 1;
    //    }
    //    if (Input.GetKeyDown(KeyCode.C))//カビ
    //    {
    //        ChangeScore = 2;

    //    }
    //}

    void Attack()//槍攻撃
    {
        if (ChangeScore == 2)
        {
          if(Interval_kabi<= timer&&ChangeScore==2)//槍が攻撃する時
          {
            animatormae.SetBool("Spear", true);
            Spear.enabled=true;
            timer += Time.deltaTime;
          }
          if (Interval_kabi >= timer && ChangeScore == 2)//槍が攻撃しない時
          {
            animatormae.SetBool("Spear", false);
            Spear.enabled=false;
          }
        }
        else
        {
            Spear.enabled = false;
        }
    }
}
