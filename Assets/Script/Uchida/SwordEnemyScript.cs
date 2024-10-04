using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyScript : MonoBehaviour
{

    /*�v���C���[���^�O�ŊǗ��������̂ƁA���������v���n�u��public�Ńh���b�N���h���b�v
     ������@���ł��Ȃ��H�C�����邩��private�ōς܂��Ă�*/
    private GameObject Player;
    private Transform PlayerTransform;
    //������Transform
    private Transform _ThisTransform;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Move();

        /*
         �g�{����ɑ��k�F�v���C���[�ɉ�]�������悤�ɐݒ肵�����肪90���̂���
        ������̂ŁA���G�l�~�[�̉摜��90����]��������Ԃŗp�ӂ�����
         */
        PlayerTransform = Player.transform;
        _ThisTransform = this.transform;
        Vector3 _Vector = (_ThisTransform.position - PlayerTransform.position);
        _ThisTransform.rotation = Quaternion.FromToRotation(Vector3.up, _Vector);

    }//end

    void Move()
    {
    }

}
