using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    [SerializeField]
    private Fade fade = null;

    public void easy()
    {
        fade.FadeIn(2, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("easy");
        });
    }
    public void normal()
    {
        fade.FadeIn(2, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("normal");
        });
    }
    public void hard()
    {
        fade.FadeIn(2, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("hard");
        });
    }

    //　ゲーム終了ボタンを押したら実行する
    public void GameEnd()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
		        Application.OpenURL("http://www.yahoo.co.jp/");
        #else
		        Application.Quit();
        #endif
    }

    public void GameSetting()
    {
        Application.LoadLevelAdditive("Setting");
    }

    public void OpenGuide()
    {
        Application.LoadLevelAdditive("Guide");
    }
}
