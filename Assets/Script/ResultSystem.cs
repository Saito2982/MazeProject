using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSystem : MonoBehaviour {

    [SerializeField]
    private Fade fade = null;
    private string sceneName;
    public static Button retryButton;

    void Start()
    {
        // 最初に選択状態にしたいボタンの設定
        retryButton = GameObject.Find("/Canvas/Retry").GetComponent<Button>();
        retryButton.Select();
    }

    //Retryボタンにカーソルフォーカス
    public static void select_retry()
    {
        retryButton.Select();
    }

    //Retry
    public void retry()
    {
        fade.FadeIn(1, () =>
        {
            fade.FadeOut(1);
            // 遷移前のScene名を取得する
            sceneName = GoalSystem.getSceneName();
            // Sceneの読み直し
            SceneManager.LoadScene(sceneName);
        });
    }

    //Title
    public void returnTitle()
    {
        fade.FadeIn(1, () =>
        {
            fade.FadeOut(1);
            //タイトルへ戻る
            SceneManager.LoadScene("title");
        });
    }
}
