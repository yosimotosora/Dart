using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public enum TitleChoice
    {
        None,
        start,
        tutorial,
        easy,
        usually,
        difficult,
    }
    public enum GameMode
    {
        Title,
        Game,
        Over,
    }
    public TitleChoice modie = TitleChoice.None;
    public Choice_Move choice_move;
    public int Choice_Point = 0;
    public float Timer = 0.0f;
    public float SccenenInterval = 4.0f;
    public string LevelSccenenName;
    public bool MoveFlag;

    // Start is called before the first frame update
    void Start()
    {
        modie = TitleChoice.None;
    }

    // Update is called once per frame
    void Update()
    {
        Choice_Point=choice_move.Choice_Point;
        Level_Select();

    }
    void Level_Select()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Choice_Point == 3)//難易度：優しい　仮
            {
                modie = TitleChoice.easy;
            }
            if (Choice_Point == 4)//難易度：普通　仮
            {
                //SceneManager.LoadScene(LevelSccenenName);
                modie = TitleChoice.usually;
            }
        }
        switch (modie)
        {
            case TitleChoice.easy:
                MoveFlag= false;
                Timer += Time.deltaTime;
                if (Timer >= SccenenInterval)
                {
                    SceneManager.LoadScene(LevelSccenenName);
                }
                break;
            case TitleChoice.usually:
                MoveFlag= false;
                Timer += Time.deltaTime;
                if (Timer >= SccenenInterval)
                {
                    SceneManager.LoadScene(LevelSccenenName);
                }
                break;



        }
                //if (MoveFlag == false)
                //{
                //    Timer += Time.deltaTime;
                //    if (Timer >= SccenenInterval)
                //    {
                //     SceneManager.LoadScene(LevelSccenenName);
                //    }
                //}
    }

}
