using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject Enemy;
    public float SpawnPoint;

    void Start()
    {
        
    }

    void Update()
    {
        SpawnPoint = Random.Range(1.98f,-4.12f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(Enemy, new Vector2(1.78f, SpawnPoint), Quaternion.identity);
        }
    }//end


}
