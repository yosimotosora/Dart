using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_egingu : MonoBehaviour
{
    public Choice_Move choice_move;
    public int Choice_Point = 0;
    public int Choice_If;
    public float t=0.5f;
    public float t_Point = 0;
    public float Nameraka = 0.5f;
    public float My_point = 0.5f;
    public bool Segyo;
    public static bool MoveFlag = true;
    public Scene_Manager scene_manager;
    [SerializeField] private Renderer My;

    // Start is called before the first frame update
    void Start()
    {
        My_point = choice_move.Start_point;
        Segyo = true;
        t = 0.5f;
        if(Choice_If==1|| Choice_If == 2)
        {
           StartCoroutine("Display");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveFlag == false) return;
        Choice_Point =choice_move.Choice_Point;
        Easing_Move();
        Seigyo();
        
       
    }
    void Easing_Move()
    {

        if (Choice_Point == Choice_If)//è„
        {
            if (t_Point == 0)
            {
                t += Time.deltaTime;
                if (t <= 0.4f)
                {
                   // t += Time.deltaTime * Nameraka;
                }
                if (t >= 1)
                {
                    t = 1;
                    t_Point = 1;

                }
                float a = Easing.BackOut(t, 1, 0, 1, 1) / 100;
                transform.position += new Vector3(0, a, 0);
            }
            if (t_Point == 1)//â∫
            {
                t -= Time.deltaTime;
                if (t <= 0.6f)
                {
                   // t -= Time.deltaTime * Nameraka;
                    
                }
                if (t <= 0)
                {
                    t = 0;
                    t_Point = 0;
                }
                float a = Easing.BackOut(t, 1, 0, 1, 1) / 100;
                transform.position += new Vector3(0, -a, 0);
            }
        }
        else if(Choice_Point > Choice_If|| Choice_Point < Choice_If&& Choice_Point >0)
        {
            transform.position = new Vector3(transform.position.x,My_point,transform.position.z) ;
            t = 0.5f;
        }
    }
    void Seigyo()
    {
        if (Segyo == true)
        {
            Vector3 start_point = transform.position;
            My_point = start_point.y;
            Segyo = false;
        }
    }
    IEnumerator Display()//ç≈èâÇÃï\é¶êÿÇËë÷Ç¶
    {
        My.enabled = false;
        yield return new WaitForSeconds(4);
        My.enabled = true;

    }
    public static void SetMoveFlag(bool flag)
    {
        MoveFlag = flag;
    }
}
