using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{

    public GameObject FinishBeam;
    private GameObject Player;//�^�O�Ŕ��肷��

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        
    }

    void Shot()
    {


       /* if (Input.GetKeyDown(KeyCode.Return)){
            Instantiate(Beam, ShotPoint.transform.position, ShotPoint.transform.rotation);
        }
       *///�v���C���[�X�N���v�g�p

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            //�Փ˂����I�u�W�F�N�g�̈ʒu�ɃR�[�q�[���e���Ă�C���X�g�����
            Instantiate(FinishBeam, collision.gameObject.transform.position, Quaternion.identity);
            //�v���C���[�̎q�I�u�W�F�N�g�ɂ���(�C���X�g�̓����ƃv���C���[�̓����͘A�����������̂�)
            FinishBeam.transform.parent = Player.transform;
        }
    }

}
