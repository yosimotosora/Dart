using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaingScript : MonoBehaviour
{
    public EnemySpawnScript enemySpawnScript;//服のスクリプト
    public GameObject Boss;//ボスをセット
    public int enemySpawnHP = 0;
    public bool SpawnFlag;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gamePlaing();
        enemySpawnHP = enemySpawnScript.ClotheHP;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnHP = enemySpawnScript.ClotheHP;
        BossStart(enemySpawnHP,Boss, SpawnFlag);
    }
    //ボス切替 (服の体力変数(int),ボスオブジェクト,ボスの体力バー)
    void BossStart(int hp,GameObject Boss,bool SpawnFlag)
    {

        if (hp <= 0)
        {
            GameManager.bossPlaing();//ゲームモードをボスに変更
            Instantiate(Boss, transform.position, transform.rotation);//ボスを出す
          
        }
    }
}
