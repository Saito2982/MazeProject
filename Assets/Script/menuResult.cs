using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuResult : MonoBehaviour {

    Button retry;
    Button title;

    void Start()
    {
        // ボタンコンポーネントの取得
        retry = GameObject.Find("/Canvas/Retry").GetComponent<Button>();
        title = GameObject.Find("/Canvas/title").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        retry.Select();
    }
}
