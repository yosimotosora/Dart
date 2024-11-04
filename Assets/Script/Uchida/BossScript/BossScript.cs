using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{

    //※publicで設定するオブジェクトが5つある
    //Skillの数が増えた場合編集する(現在二種類・0から数える)
    private int SkillNumber=2;

    public int BossHP=30;//ボスのHP
    public Slider _Slider;//スライダー

    public int SkillRange;//スキルをランダムで設定する
    private float SkillTimer;//タイマー
    public float SkillTime;//スキルを発動する間隔(Update内でRandomにする)
    private Vector2 SPpos;//ShotPoint(SP)のPosition(Pos)

    //Bubble
    public GameObject BubblePrefab;//泡のプレハブ
    public GameObject ShotPoint;//龍の口元にあるShotPointオブジェクト

    //ThreeShot
    public GameObject BossBullet1;//直線に移動
    public GameObject BossBullet2;//左上に移動
    public GameObject BossBullet3;//右上に移動

    void Start()
    {

        SkillTimer = 0;//タイマーの初期化
        BossHP = 3;

    }

    void Update()
    {

        //Updateで常にスキルの種類を切り替え
        SkillRange=Random.Range(0,SkillNumber);
        SkillTime = Random.Range(0.4f,1.0f);
        SkillTimer+= Time.deltaTime;//タイマーの設定

        SPpos = ShotPoint.transform.position;//UpdateでPositionを随時更新
        _Slider.value = BossHP;//

        Attack();
        
    }

    void Attack()
    {

        //もしSkillTime分時間経過したら
        if (SkillTimer >= SkillTime)
        {

            switch(SkillRange){
                case 0:
                    Bubble();
                    break;
                case 1:
                    ThreeShot();
                    break;
                default:
                    ThreeShot();
                    break;
            }//switch
            SkillTimer = 0;//タイマーの初期化

        }//if

    }//end attack

    void Bubble()
    {

        /*
         大きな泡一つを撃つ攻撃
         */

        //(泡のプレハブ,ShotPointの位置,回転が0)
        Instantiate(BubblePrefab, SPpos, Quaternion.identity);

    }
    void ThreeShot()
    {

        /*
         三つの泡をそれぞれ三方向に放つ
         */

        Instantiate(BossBullet1, SPpos, Quaternion.identity);
        Instantiate(BossBullet2, SPpos, Quaternion.identity);
        Instantiate(BossBullet3, SPpos, Quaternion.identity);

    }

    //各BulletScriptで使用
    void Damage(int AP)
    {

        BossHP -= AP;

    }

    void Dead()
    {

        if (BossHP <= 0)
        {

        }

    }//end Dead


}//END
