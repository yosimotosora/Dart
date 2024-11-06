using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEnemyScript : MonoBehaviour
{

    private float MoveSpeed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Time.deltaTime*MoveSpeed*transform.right;
    }
}
