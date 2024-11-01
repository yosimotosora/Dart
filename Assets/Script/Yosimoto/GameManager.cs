
using UnityEngine;
using UnityEngine.SceneManagement;

// enum
// enumは列挙型と呼ばれ、整数定数(列挙定数と呼ばれる)を表す
// 一連の名前付き値で構成されるデータ型のことを指します
// enumを使うことで数値に意味を持たせることができます
// 何も指定しない場合は一番上から順に0から始まる整数の連番になる
// 今回はゲームの状態を表すために使用する
// 使い方は enum型の名前.定数名 と記述します
// 例えば下の Init を使用する場合は GameMode.Init と記述します
public enum GameMode
{
    Init,   // 0 : 初期化中
    Opening, // 1 : オープニング演出中
    GamePlaing, // 2 : ゲームプレイ中
    GameOver,   // 3 : ゲームオーバー演出中
    GameClear,   // 4 : ゲームクリア演出中
    Title,       //タイトル
    GameScenes//ゲームシーン

}

public class GameManager : MonoBehaviour
{
    // インスペクターにゲームモードを表示する用の変数
    // ReadOnly属性で表示のみ、編集不可に設定
    // ReadOnly属性を使用するためにはScript/Commonフォルダ内にある
    // ReadOnlyAttribute.cs と ReadOnlyDrawer.cs が必要
    [SerializeField]
    [Space(10)]  // Space属性 → インスペクターの項目に引数で指定した隙間を空けることができる
    private GameMode GameMode;

    // 実際にゲームモードを制御する用の変数
    // staticを使用している変数はゲームに対して1つしか存在しない
    // 外部から自由に変更させないためにprivateに設定している
    private static GameMode State = 0;


    // 汎用タイマー
    private float Timer = 0.0f;

    // オープニング演出の時間
    [Header("オープニング演出の時間(秒)")]  // Header属性　→　インスペクターに指定した文字をコメントとして表示できる
    public float OpeningTime = 3.0f;
    // ゲームオーバー画面に移行するまでの時間
    [Header("ゲームオーバー演出の時間(秒)")]

    public float GameOverIntervalTime = 3.0f;
    // ゲームクリア画面に移行するまでの時間
    [Header("ゲームクリア演出の時間(秒)")]
    public float GameClearIntervalTime = 3.0f;
    [Header("ゲームシーンに行くまでの時間(秒)")]
    public float GameScenesIntervalTime = 3.0f;




    public string dainisutezi;
    void Start()
    {
        // ゲームモードを初期化モードに設定
        State = GameMode.Init;
    }

    void Update()
    {
        // 全部で23種類あるデザインパターンと呼ばれるプログラム設計の1つである
        // ステートパターンを使用してゲームモードごとに処理を分岐させる
        // 実際にはStateの値を変更する事によって分岐させている
        switch (State)
        {
            // 初期化モード
            case GameMode.Init:
                // タイマーをリセット
                Timer = 0.0f;
                // ゲームモードをオープニングに変更
                State = GameMode.Opening;
                //===================================================
                // プレイヤーと敵の移動フラグをfalseに設定
                //===================================================
                

                break;
            // オープニング中
            case GameMode.Opening:
                // タイマー加算
                Timer += Time.deltaTime;
                // タイマーがオープニング演出の時間を超えたら
                if (Timer > OpeningTime)
                {
                    // タイマーをリセット
                    Timer = 0.0f;
                    // ゲームモードをプレイ中に変更
                    State = GameMode.GamePlaing;
                    //===================================================
                    // プレイヤーと敵の移動フラグをtrueに設定
                    //===================================================
                    

                }
                break;
            // ゲームプレイ中
            case GameMode.GamePlaing:
                // ゲームプレイ中にゲームマネージャーは何もしない
                break;
            // ゲームオーバー演出中
            case GameMode.GameOver:
                // タイマー加算
                Timer += Time.deltaTime;
                // タイマーがゲームオーバー演出の時間を超えたら
                if (Timer > GameOverIntervalTime)
                {
                    // ゲームオーバーシーンを読み込む
                    SceneManager.LoadScene("OverScene");
                }
                break;
            // ゲームクリア演出中
            case GameMode.GameClear:
                // タイマー加算
                Timer += Time.deltaTime;
                // タイマーがゲームクリア演出の時間を超えたら


                if (Timer > GameClearIntervalTime)
                {
                    // ゲームクリアシーンを読み込む

                    //SceneManager.LoadScene(dainisutezi);
                }
                break;
            // 万が一Stateに変な(値が入ったとき用の処理
            // 今回の場合だとほぼありえません
            case GameMode.Title:
                SceneManager.LoadScene("TitleScenes");
                break;
            case GameMode.GameScenes:
                if (Timer > GameScenesIntervalTime)
                {
                 SceneManager.LoadScene("Game");

                }
                break;
            default:
                // 初期化モードに移行
                State = GameMode.Init;
                break;
        }
        // 表示用のゲームモードを更新
        GameMode = State;
    }

    // ゲームオーバー時に呼び出すことでゲームモードをゲームクリアの状態に変更するための関数
    // これを敵がプレイヤーに当たったときに呼び出す
    public static void GameOvered()
    {
        // ゲームモードをゲームオーバに変更
        State = GameMode.GameOver;
        //===================================================
        // プレイヤーと敵の移動フラグをfalseに設定
        //===================================================
        Player_main.SetMoveFlag(false);
        Background.SetMoveFlag(false);

    }
    // ゲームクリア時に呼び出すことでゲームモードをゲームクリアの状態に変更するための関数
    // この関数をプレイヤー側でゲームをクリアしたときに呼び出す
    public static void GameCleared()
    {
        State = GameMode.GameClear;
        //===================================================
        // プレイヤーと敵の移動フラグをfalseに設定
        //===================================================
        Player_main.SetMoveFlag(false);
        Background.SetMoveFlag(false);
    }
    public static void Title()
    {
        State= GameMode.Title;
    }
    public static void Game()
    {
        State = GameMode.GameScenes;
        Choice_egingu.SetMoveFlag(false);
    }
}

