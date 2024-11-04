using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 外部からアクセスするためのインスタンス(実体)
    public static SoundManager instance;
    // BGMの音源データ保存用の配列
    [SerializeField]
    private AudioClip[] BGMData = new AudioClip[1];
    // SEの音源データ保存用の配列
    [SerializeField]
    private AudioClip[] SEData = new AudioClip[1];

    // BGM再生用のAudioSource
    private AudioSource BGMPlayer;
    // SE再生用のAudioSource配列
    // 配列にしたのは多重再生を実現するため
    private AudioSource[] SEPlayer;
    // SE再生用AudioSourceの最大数
    [SerializeField]
    private int SEPlayerMax = 10;
    // Start is called before the first frame update
    void Start()
    {
        // 自身の実体をinstanceに設定する
        instance = this;

        // BGM用にAudioSourceコンポーネントを追加する
        BGMPlayer = gameObject.AddComponent<AudioSource>();
        // 自動再生を無効化する
        BGMPlayer.playOnAwake = false;
        // ループ再生を有効にする
        BGMPlayer.loop = true;
        // 再生の優先度を上げる
        BGMPlayer.priority = 0;
        // BGMの先頭にデータが登録されていたら
        if (BGMData[0] != null)
        {
            // BGM用AudioSourceのクリップにデータをセットする
            BGMPlayer.clip = BGMData[0];
            // BGMを再生する
            BGMPlayer.Play();
        }

        // SEの多重再生を実現するためにAudioSourceコンポーネントの配列を用意する
        SEPlayer = new AudioSource[SEPlayerMax];
        // 最大数までAudioSourceコンポーネントを追加する
        for (int i = 0; i < SEPlayerMax; i++)
        {
            SEPlayer[i] = gameObject.AddComponent<AudioSource>();
            // 自動再生を無効化する
            SEPlayer[i].playOnAwake = false;
        }
    }
    public void PlayBGM(uint index)
    {
        // BGMの音源データ配列がなければ何もしない
        if (BGMData == null) return;
        // インデックス番号が範囲外なら何もしない
        if (index >= BGMData.Length) return;
        // インデックスで指定した場所に音源データがなければ何もしない
        if (BGMData[index] == null) return;

        // AudioSourceに音源データを設定
        BGMPlayer.clip = BGMData[index];
        // 設定した音源データの再生を開始する
        BGMPlayer.Play();
    }
    public  void PlaySE(uint index)
    {
        // BGMの音源データ配列がなければ何もしない
        if (SEData == null) return;
        // インデックス番号が範囲外なら何もしない
        if (index >= SEData.Length) return;
        // インデックスで指定した場所に音源データがなければ何もしない
        if (SEData[index] == null) return;

        // SE用のAudioSource配列で使っていない(再生中ではない)ものを検索
        for (int i = 0; i < SEPlayerMax; i++)
        {
            // i番目のAudioSourceが再生中ではなければ
            if (SEPlayer[i].isPlaying == false)
            {
                // AudioSourceに音源データを設定
                SEPlayer[i].clip = SEData[index];
                // 設定した音源データの再生を開始する
                SEPlayer[i].Play();
                // 再生は1度で良いのでループを抜ける
                break;
            }
        }
    }
    public void OnePlaySE(bool a=true, uint Number=0)
    {
        if (a == true)
        {
            PlaySE(Number);
            a = false;
        }
    }
}
