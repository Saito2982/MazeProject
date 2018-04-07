using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{

    public static int MAX_TIME = 10; // カウントダウンの開始値
    float timeCounter = MAX_TIME;

    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = MAX_TIME.ToString();
    }

    void Update()
    {
        timeCounter -= Time.deltaTime;

        // マイナス値にならないようにしている
        timeCounter = Mathf.Max(timeCounter, 0.0f);
        GetComponent<UnityEngine.UI.Text>().text = ((int)timeCounter).ToString();
    }
}

