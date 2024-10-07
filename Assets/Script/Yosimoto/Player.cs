using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject goal;//�ړI�n(�R���|�[�l���g)��ݒ肷��(�v���C���[)
    public float distance;//�v���C���[�ƓG�̋������i�[����ϐ�
    Vector3 mousePos, pos;
    public float MoveSpeed = 5.0f;//�X�s�[�h
    public Vector3 Offset = Vector3.zero;
    [Range(0f,0.25f)]
    public float interpolationRatio=0.1f;
    private Animator animatorusiro;
    private Animator animatormae;//�A�j���[�V�����؂�ւ�
    float tortal_x = 0.0f;//�A�j���[�V�����Ǘ�
    float tortal_y = 0.0f;//�A�j���[�V�����Ǘ�

    // Start is called before the first frame update

    void Start()
    {
        //goal = GameObject.Find("plare");//�����ŖړI�n���擾
        animatormae = GetComponent<Animator>();
        animatorusiro = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//��������
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))//������������
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
        //���̃I�u�W�F�N�g�����̃I�u�W�F�N�g(goal)�ɑ΂��Ă��̑����ňړ�����B
        Change();//�ϐg
    }
    void Change()//�ϐg
    {
        if (Input.GetKeyDown(KeyCode.Z))//��
        {
            tortal_x = 1;
            tortal_y = 0;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
        if (Input.GetKeyDown(KeyCode.X))//�P�`���b�v
        {
            tortal_x = 1;
            tortal_y = 1;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
        if (Input.GetKeyDown(KeyCode.C))//�J�r
        {
            tortal_x = 1;
            tortal_y = -1;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
        if (Input.GetKeyDown(KeyCode.V))//�J�r
        {
            tortal_x = 0;
            tortal_y = 1;
            animatorusiro.SetFloat("Move_x", tortal_x);
            animatorusiro.SetFloat("Move_y", tortal_y);
        }
    }
}
