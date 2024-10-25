using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice: MonoBehaviour
{
    public Choice_Move choice_move;
    public int Choice_Point = 0;
    public int Choice_Count = 0;
    void Update_Variable()
    {
        Choice_Point=choice_move.Choice_Point;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Update_Variable();
        



    }
}
