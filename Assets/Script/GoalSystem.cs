using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalSystem : MonoBehaviour {

    // MessageTextゲームオブジェクト
    [SerializeField]
    private Text messageText;
    [SerializeField]
    private Fade fade = null;
    // 現在読み込んでいるシーン名
    public static string currentScene;

    // 衝突の瞬間判定
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //ゴール時テキスト更新
            messageText.text = "GOAL!!";
            messageText.enabled = true;
            //現在の読み込みシーン名取得
            currentScene = SceneManager.GetActiveScene().name;
            //タイマー停止
            FlagController.setTimerFlag(false);
            //resultシーンの読み込み
            Invoke("loadSceneMethod", 1.0f);
        }
    }

    void loadSceneMethod()
    {
        fade.FadeIn(2, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("result");
        });
    }

    public static string getSceneName()
    {
        //遷移前のシーン名を返す
        return currentScene;
    }


}
