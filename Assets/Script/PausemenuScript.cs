using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausemenuScript : MonoBehaviour {

    [SerializeField]
    private Fade fade = null;
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    public void resume()
    {
        //　ポーズUIのアクティブ、非アクティブを切り替え
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;

    }
    public void retry()
    {
        Time.timeScale = 1f;
        FlagController.setTimerFlag();
        fade.FadeIn(1, () =>
        {
            fade.FadeOut(1);
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        });
    }
    public void retire()
    {
        Time.timeScale = 1f;
        FlagController.setTimerFlag();
        fade.FadeIn(1, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("title");
        });
    }

}
