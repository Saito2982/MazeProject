using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    Button easy;
    Button normal;
    Button hard;

    void Start()
    {
        // ボタンコンポーネントの取得
        easy = GameObject.Find("/Canvas/ButtonArea/EASY").GetComponent<Button>();
        normal = GameObject.Find("/Canvas/ButtonArea/NORMAL").GetComponent<Button>();
        hard = GameObject.Find("/Canvas/ButtonArea/HARD").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        easy.Select();
    }
}