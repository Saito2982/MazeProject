using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TitleSystem : MonoBehaviour
{
    [SerializeField]
    private Fade fade = null;
    private Button easyButton;
    public static Button SettingButton;
    public static Button GuideButton;
    public AudioMixer mixer;
    private float Master, BGM, SE;

    void Start()
    {
        // 最初に選択状態にしたいボタンの設定
        easyButton = GameObject.Find("/Canvas/ButtonArea/EASY").GetComponent<Button>();
        easyButton.Select();

        // 保存された情報があれば読み込み
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            Master = PlayerPrefs.GetFloat("MasterVolume");
            mixer.SetFloat("MasterVolume", Master);

            BGM = PlayerPrefs.GetFloat("BGMVolume");
            mixer.SetFloat("BGMVolume", BGM);

            SE = PlayerPrefs.GetFloat("SEVolume");
            mixer.SetFloat("SEVolume", SE);
        }
    }

    //設定画面から戻ったときカーソルフォーカス
    public static void select_setting()
    {
        SettingButton = GameObject.Find("/Canvas/ButtonArea/Setting").GetComponent<Button>();
        SettingButton.Select();
    }

    //遊び方画面から戻ったときカーソルフォーカス
    public static void select_guide()
    {
        GuideButton = GameObject.Find("/Canvas/ButtonArea/Guide").GetComponent<Button>();
        GuideButton.Select();
    }

    //EASY
    public void easy()
    {
        fade.FadeIn(2, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("easy");
        });
    }

    //NORMAL
    public void normal()
    {
        fade.FadeIn(2, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("normal");
        });
    }

    //HARD
    public void hard()
    {
        fade.FadeIn(2, () =>
        {
            fade.FadeOut(1);
            SceneManager.LoadScene("hard");
        });
    }

    //ゲーム終了
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

    //設定
    public void GameSetting()
    {
        Application.LoadLevelAdditive("Setting");
    }

    //遊び方
    public void OpenGuide()
    {
        Application.LoadLevelAdditive("Guide");
    }
}
