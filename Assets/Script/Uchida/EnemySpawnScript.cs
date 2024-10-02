using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public float SpawnRange;
    public GameObject Enemy;

    void Start()
    {
        
    }
    void Update()
    {
        SpawnRange = Random.Range(1.98f, -4.12f);
    }

    void OnCollisioneEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Bullet")
        {
            Instantiate(Enemy,new Vector2(1.78f,SpawnRange),Quaternion.identity)
        }
    }//end collision

}
