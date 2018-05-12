using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingSystem : MonoBehaviour {

    public AudioMixer mixer;
    private Slider Masterslider;
    private Slider BGMslider;
    private Slider SEslider;
    private Button _Apply;
    private Button Guide;
    private float Master, BGM, SE;

    void Start()
    {
        //コンポーネントの取得
        Masterslider = GameObject.Find("/Canvas/SettingPanel/Slider/Master").GetComponent<Slider>();
        BGMslider = GameObject.Find("/Canvas/SettingPanel/Slider/BGM").GetComponent<Slider>();
        SEslider = GameObject.Find("/Canvas/SettingPanel/Slider/SE").GetComponent<Slider>();
        _Apply = GameObject.Find("/Canvas/SettingPanel/Apply").GetComponent<Button>();

        //カーソル初期選択
        _Apply.Select();

        //保存された情報があれば読み込み
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            Master = PlayerPrefs.GetFloat("MasterVolume");
            Masterslider.value = Master;
            mixer.SetFloat("MasterVolume", Master);

            BGM = PlayerPrefs.GetFloat("BGMVolume");
            BGMslider.value = BGM;
            mixer.SetFloat("BGMVolume", BGM);

            SE = PlayerPrefs.GetFloat("SEVolume");
            SEslider.value = SE;
            mixer.SetFloat("SEVolume", SE);
        }
    }

    //Masterボリュームの変更
    public void ChangeMasterVolume()
    {
        mixer.SetFloat("MasterVolume", Masterslider.value);
    }

    //BGMボリュームの変更
    public void ChangeBGMVolume()
    {
        mixer.SetFloat("BGMVolume", BGMslider.value);
    }

    //SEボリュームの変更
    public void ChangeSEVolume()
    {
        mixer.SetFloat("SEVolume", SEslider.value);
    }

    public void Apply()
    {
        //音量変更保存
        PlayerPrefs.SetFloat("MasterVolume", Masterslider.value);
        PlayerPrefs.SetFloat("BGMVolume", BGMslider.value);
        PlayerPrefs.SetFloat("SEVolume", SEslider.value);

        //設定画面破棄
        SceneManager.UnloadSceneAsync("Setting");
        Resources.UnloadUnusedAssets();
        //カーソルフォーカス
        TitleSystem.select_setting();
    }

}
