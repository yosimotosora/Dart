using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Attack : MonoBehaviour
{
    public float Interval_kabi = Player_main.Interval_kabi;
    public float timer=Player_main.timer;
    public int ChangeScore = 0;//�ϐg�؂�ւ�
    private Animator animatormae;
    // Start is called before the first frame update
    void Start()
    {
        animatormae = GetComponent<Animator>();//�A�j���[�V����
    }
    // Update is called once per frame
    void Update()
    {
        Change();
    }
    void Change()
    {
        if (Input.GetKeyDown(KeyCode.Z))//��
        {
            ChangeScore = 0;
        }
        if (Input.GetKeyDown(KeyCode.X))//�P�`���b�v
        {
            ChangeScore = 1;
        }
        if (Input.GetKeyDown(KeyCode.C))//�J�r
        {
            ChangeScore = 2;

        }
    }

    void Attack()//���U��
    {
        if(Interval_kabi<= timer)
        {
            animatormae.SetBool("attack", true);
        }
    }
}
