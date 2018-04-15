using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TimerScript : MonoBehaviour
{
    private float time;
    //　タイマー表示用テキスト
    public static Text text;
    public static bool isStart_timer;


    void Start()
    {
        time = 0.0f;
        text = GetComponent<Text>();
    }

    void Update()
    {
        isStart_timer = FlagController.getTimerFlag();
        if ( isStart_timer )
        {
            time += Time.deltaTime;//毎フレームの時間を加算.
            int minute = (int)time / 60;//分.timeを60で割った値.
            int second = (int)time % 60;//秒.timeを60で割った余り.
            int msecond = (int)(time * 1000 % 1000);
            string minText, secText, msecText;//分・秒を用意.

            if (minute < 10)
                minText = "0" + minute.ToString();//ToStringでint→stringに変換.
            else
                minText = minute.ToString();
            if (second < 10)
                secText = "0" + second.ToString();//上に同じく.
            else
                secText = second.ToString();

            if (msecond < 10)
                msecText = "00" + msecond.ToString();

            else if (msecond < 100)
                msecText = "0" + msecond.ToString();

            else
                msecText = msecond.ToString();

            text.text = minText + ":" + secText + "." + msecText;

        }
    }

    public static string getResultTime()
    {
        return text.text;
    }
}