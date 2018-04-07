using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour {

    [SerializeField]
    private Fade fade = null;
    private string sceneName;

    public void retry()
    {
        fade.FadeIn(1, () =>
        {
            fade.FadeOut(1);
            // 遷移前のScene名を取得する
            sceneName = GoalScript.getSceneName();
            // Sceneの読み直し
            SceneManager.LoadScene(sceneName);
        });
    }
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
