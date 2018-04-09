using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {
    // MessageTextゲームオブジェクト
    public Text messageText;
    [SerializeField]
    Fade fade = null;
    // 現在読み込んでいるシーンの名前を取得
    public static string currentScene;


    // Use this for initialization
    void Start () {
        //messageText = GetComponentInChildren<Text>();//UIのテキストの取得の仕方
        messageText.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {


    }

    // 衝突の瞬間判定
    void OnCollisionEnter(Collision other)
    {    
        Debug.Log(other.gameObject.name + "Enter");
        messageText.text = "GOAL!!";
        currentScene = SceneManager.GetActiveScene().name;
        FlagController.setTimerFlag(false);
        SceneManager.LoadScene("result");
        //Invoke("DelayMethod", 1.0f);
    }

    void DelayMethod()
    {
        fade.FadeIn(1, () =>
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
