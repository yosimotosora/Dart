using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class Spear_Attack : MonoBehaviour
{
    public float Interval_kabi = Player_main.Interval_kabi_Kari;
    public float timer;//=Player_main.Timer_Kari;
    public Player_main player_main;
    public int ChangeScore = 0;//�ϐg�؂�ւ�
    private Animator animatormae;
    [SerializeField] private Renderer Spear;
    public float Timer_Spear;//�����A�j���[�V�������͂��߂�^�C�}�[�J�n�̂��߂̕ϐ�
    public float Interval_Spear;//�����U�����n�߂Ă����Interval
    // Start is called before the first frame update
    void Start()
    {
        animatormae = GetComponent<Animator>();//�A�j���[�V����
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

    void Attack()//���U��
    {
        if (ChangeScore == 2)
        {
          if(Interval_kabi< timer&&ChangeScore==2)//�����U�����鎞
          {
            animatormae.SetBool("Spear", true);
            Spear.enabled=true;//�摜�؂�ւ�
            Timer_Spear+= Time.deltaTime;
                
          }
            if (Interval_kabi >= timer && ChangeScore == 2)
            {
                Spear.enabled = false;
                animatormae.SetBool("Spear", false);
            }
          if (ChangeScore == 2 && Timer_Spear >= Interval_Spear)//�����U�����n�߂Ă���U���I���܂ł̌v���@
          {
                animatormae.SetBool("Spear", false);
                Spear.enabled = false;
                player_main.Timer = 0;
                Timer_Spear =0;
          }
          //  else if (Interval_kabi >= timer&& ChangeScore == 2)//�����U�����Ȃ���
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
