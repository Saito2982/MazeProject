using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuPause : MonoBehaviour
{

    Button resume;
    Button retry;
    Button retire;

    void Start()
    {
        // ボタンコンポーネントの取得
        resume = GameObject.Find("/UI/menu/Resume").GetComponent<Button>();
        retry = GameObject.Find("/UI/menu/Retry").GetComponent<Button>();
        retire = GameObject.Find("/UI/menu/Retire").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        resume.Select();
    }
}
