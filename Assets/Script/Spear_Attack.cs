using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Attack : MonoBehaviour
{
    public float Interval_kabi = Player_main.Interval_kabi;
    public float timer=Player_main.timer;
    public int ChangeScore = 0;//変身切り替え
    private Animator animatormae;
    // Start is called before the first frame update
    void Start()
    {
        animatormae = GetComponent<Animator>();//アニメーション
    }
    // Update is called once per frame
    void Update()
    {
        Change();
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

    void Attack()//槍攻撃
    {
        if(Interval_kabi<= timer)
        {
            animatormae.SetBool("attack", true);
        }
    }
}
