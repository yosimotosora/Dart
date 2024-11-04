using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float Speed = 3.0f;
    public GameObject Backgrouonda;
    public GameObject My;
    public GameObject Respawn;
    public float Backgrouond_x;
    public float My_x;
    public static bool MoveFlag=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveFlag == true)
        {
        Move();
        float HP = Player.HP;
        if (HP == 0)
        {
            GameManager.GameOvered();
        }
        }

    }
    void Move()
    {
        Vector3 BackgrouondPint_y= Backgrouonda.transform.position;
        Backgrouond_x = BackgrouondPint_y.x;
        Vector3 MyPint=My.transform.position;
        My_x = MyPint.x;
        transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime; 
        if (Backgrouond_x>=My_x)
        {
            transform.position = Respawn.transform.position;
        }
    }
    public static void SetMoveFlag(bool flag)
    {
        MoveFlag = flag;
    }
}
