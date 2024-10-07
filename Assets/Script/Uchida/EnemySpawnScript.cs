using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    //OnTriggerEnter
    private float SpawnRange;
    public GameObject Enemy;
    public int ClotheHP=5;
    public bool SpawnBool;

    void Start()
    {
        
    }
    void Update()
    {
        SpawnRange = Random.Range(2.2f, -4.12f);

        if (ClotheHP % 4 == 0) {
            SpawnBool = true;
            ClotheHP -= 1;
        }
        if (SpawnBool == true)
        {
            SpawnBool = false;
            Instantiate(Enemy, new Vector2(1.78f, SpawnRange), Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag =="Bullet")
        {
            ClotheHP -= 1;
            
        }
        if (collider.gameObject.name == "tama_ketyappu_main")
        {
            ClotheHP -= 1;
            
        }
    }//end


}
