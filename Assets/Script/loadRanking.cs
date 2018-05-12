using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadRanking : MonoBehaviour {

    private string timerText;

    void Start () {

        //ゴール時の時間取得(00:00.00)
        timerText = TimerScript.getResultTime();

        string[] words = timerText.Split(':', '.');

        //日、時、分、秒、ミリ
        var timeScore = new System.TimeSpan(0, 0, int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]));
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
    }
}
