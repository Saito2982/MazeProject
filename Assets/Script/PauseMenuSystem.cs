using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuSystem : MonoBehaviour {

    [SerializeField]
    private Fade fade = null;
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private AudioSource AudioSource;

    private Button resumeButton;

    void Start()
    {
        // 最初に選択状態にしたいボタンの設定
        resumeButton = GameObject.Find("/UI/menu/Resume").GetComponent<Button>();
        pauseUI.SetActive(false);
        resumeButton.Select();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") || Input.GetButtonDown("StartButton"))
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                this.AudioSource.Pause();
            }
            //　ポーズUIが表示されてなければ通常通り進行
            else
            {
                this.AudioSource.UnPause();
                Time.timeScale = 1f;
            }
        }
    }


    //Resume
    public void resume()
    {
        //　ポーズUIのアクティブ、非アクティブを切り替え
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;

    }

    //Retry
    public void retry()
    {
        Time.timeScale = 1f;
        fade.FadeIn(1, () =>
        {
            fade.FadeOut(1);
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        });
    }

    //Retire
    public void retire()
    {
        Time.timeScale = 1f;
        fade.FadeIn(1, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("title");
        });
    }

}
