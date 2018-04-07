using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultTime : MonoBehaviour {
    //　タイマー表示用テキスト
    public static Text timerText;

    void Start () {
        //タイマーテキストコンポーネント取得
        timerText = GetComponent<Text>();
        //ゴール時の時間取得
        timerText.text = TimerScript.getResultTime();
    }
}
