using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuResult : MonoBehaviour {

    private Button retry;
    private Button title;
    private string timerText;

    void Start()
    {
        // ボタンコンポーネントの取得
        retry = GameObject.Find("/Canvas/Retry").GetComponent<Button>();
        title = GameObject.Find("/Canvas/title").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        retry.Select();

        //ゴール時の時間取得(00:00.00)
        timerText = TimerScript.getResultTime();

        string[] words = timerText.Split(':', '.');

        //日、時、分、秒、ミリ
        var timeScore = new System.TimeSpan(0, 0, int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]));
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
    }
}
