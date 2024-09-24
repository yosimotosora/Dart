using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.AI;


public class Player_main : MonoBehaviour
{
    [SerializeField] float speed;
    public float MoveSpeed = 5.0f;//�X�s�[�h
    public Vector3 Offset = Vector3.zero;
    public static float timer = 0.0f;
    public float Interval_ase = 0.0f;//���̋ʂ̃C���^�[�o��
    public float Interval_ketyappu = 0.0f;//�P�`���b�v�̋ʂ̃C���^�[�o��
    public static float Interval_kabi = 0.0f;//�J�r�̋ʂ̃C���^�[�o��
    public GameObject BulletPrefab_ase;
    public GameObject BulletPrefab_ketyappu;
    public Transform ShotPoint;
    public Transform ShotPoint_ketyappu;
    public int ChangeScore=0;//�ϐg�؂�ւ�
    private Animator animatormae;

    Vector3 beforemousePos;

    // Start is called before the first frame update
    void Start()
    {
        animatormae = GetComponent<Animator>();//�A�j���[�V����
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
    void Move()//�ړ�
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
            //�J��������Ƃ���pos�̈ʒu
            Vector3 vec=pos - beforemousePos;
            transform.position+=vec;
            beforemousePos= pos;

            //timer+= Time.deltaTime;
            //if ( timer >= Interval)
            //{
            //    GameObject obj = Instantiate(BulletPrefab, ShotPoint.position, ShotPoint.rotation);
            //    //�^�C�}�[�����Z�b�g
            //    timer = 0.0f;
            //}
        }

}
    void Shooting()
    {
        if (Input.GetMouseButton(0))
        {

            timer += Time.deltaTime;
          if (ChangeScore==0&&timer>=Interval_ase)//��
          {
                GameObject obj = Instantiate(BulletPrefab_ase, ShotPoint.position, ShotPoint.rotation);
                //�^�C�}�[���Z�b�g
                timer = 0;
          }
            if (ChangeScore == 1&&timer>=Interval_ketyappu)//�P�`���b�v
            {
                GameObject obj = Instantiate(BulletPrefab_ketyappu, ShotPoint_ketyappu.position, ShotPoint_ketyappu.rotation);
                //�^�C�}�[���Z�b�g
                timer = 0;
            }
              if (ChangeScore ==2 && timer >= Interval_ketyappu)//�J�r
              {
                
              }
              if (ChangeScore == 2 && timer <= Interval_ketyappu)//�J�r
              {
                
              }
        }
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

