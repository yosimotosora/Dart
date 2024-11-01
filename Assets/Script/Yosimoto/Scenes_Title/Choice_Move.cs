using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Move : MonoBehaviour
{
    public enum GameModie
    {
        None,
        start,
        tutorial,
        easy,
        usually,
        difficult,
    }
    public GameModie modie=GameModie.None;
    public int Choice_Point=0;
    public float t;
    public float t_Point = 0;
    public GameObject Tyutorial_Point;
    public GameObject Start_Point;
    public GameObject One_Point;
    public GameObject Two_Point;
    public float Nameraka = 0.5f;
    public float Start_point = 0.5f;
    public bool Segyo;
    public bool Start_Segyo;
    private bool MoveFlag;
    public Scene_Manager scene_manager;
    [SerializeField] private Renderer Start_Select;
    [SerializeField] private Renderer Tyutorial_Select;
    [SerializeField] private Renderer One;
    [SerializeField] private Renderer Two;
    [SerializeField] private Renderer Three;
    //public bool moveFlg;
    // Start is called before the first frame update
    void Start()
    {
        Segyo = true;
        StartCoroutine("Display");
        One.enabled = false;
        Two.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
         //MoveFlag =scene_manager.MoveFlag;
        if (MoveFlag == false) return;
        if (Start_Segyo==true)
        {
          Move();
        }
        Decision();
    }
    void Move()
    {
        if (Choice_Point >= 0&& Choice_Point <= 2)
        {
        if (Input.GetKeyDown(KeyCode.LeftArrow))//左
        {
            Choice_Point -= 1;
            if (Choice_Point<=0)
            {
                Choice_Point = 2;
            }
        }
            if (Input.GetKeyDown(KeyCode.RightArrow))//右
            {
                Choice_Point += 1;
                if (Choice_Point >= 3)
                {
                    Choice_Point = 1;
                }
            }
                if (Choice_Point == 2)
                {
                    transform.position= new Vector3(Start_Point.transform.position.x, Start_Point.transform.position.y, Start_Point.transform.position.z);
                modie = GameModie.start;
                }
                    if (Choice_Point == 1)
                    {
                        transform.position = new Vector3(Tyutorial_Point.transform.position.x, Tyutorial_Point.transform.position.y, Tyutorial_Point.transform.position.z);
                        modie= GameModie.tutorial;
                    }

        }//スタートかチュートリアル
        if (Choice_Point >= 3&& Choice_Point <= 4)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))//左
            {
                Choice_Point -= 1;
                if (Choice_Point <= 2)
                {
                    Choice_Point = 4;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))//右
            {
                Choice_Point += 1;
                if (Choice_Point >= 5)
                {
                    Choice_Point = 3;
                }
            }
            if (Choice_Point == 3)
            {
                transform.position = new Vector3(One_Point.transform.position.x, One_Point.transform.position.y, One_Point.transform.position.z);
                modie=GameModie.easy;
            }
            if (Choice_Point == 4)
            {
                transform.position = new Vector3(Two_Point.transform.position.x, Two_Point.transform.position.y, Two_Point.transform.position.z);
                modie = GameModie.usually;
            }
        }
    }
    void Decision()
    {
        if(Input.GetKeyDown(KeyCode.Return)) 
        {
          if(Choice_Point == 1)
          {
           Start_Select.enabled = false;
           Tyutorial_Select.enabled= false;
           One.enabled = true;
           Two.enabled = true;
           Choice_Point = 3;
          }
        } 

    }
    IEnumerator Display()
    {
      
        yield return new WaitForSeconds(4);
        Start_Segyo = true;

    }
}

