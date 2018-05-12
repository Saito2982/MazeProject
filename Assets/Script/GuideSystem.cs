using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GuideSystem : MonoBehaviour {

    Button close;

    [SerializeField]
    private Image ClickImage;

    void Start()
    {
        //×ボタンイベントトリガー
        EventTrigger trigger = ClickImage.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // なんのイベントを検出するか
        entry.eventID = EventTriggerType.PointerClick;
        // EventTriggerに追加
        trigger.triggers.Add(entry);

        // 最初に選択状態にしたいボタンの設定
        close = GameObject.Find("/Canvas/Close").GetComponent<Button>();
        close.Select();
    }

    //Closeボタン
    public void GuideClose()
    {
        SceneManager.UnloadSceneAsync("Guide");
        Resources.UnloadUnusedAssets();
        TitleSystem.select_guide();
    }
}
