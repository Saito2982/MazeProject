using UnityEngine;

public class CountDownController : MonoBehaviour
{
    public static Animator anim;
    [SerializeField]
    private GameObject countDownUI;
    private static bool isStart_anim;

    void Start()
    {
        //Animatorコンポーネント取得
        anim = countDownUI.GetComponent<Animator>();
        //カウントダウンアニメーションOFF
        countDownUI.SetActive(false);
    }

    void Update()
    {
        //カウントダウンアニメーションフラグ取得
        isStart_anim = FlagController.getCountDownAnimationFlag();

        if (isStart_anim)
        {
            //フラグがたったらアニメーション開始
            countDownUI.SetActive(true);
            anim.SetTrigger("CountDownTrigger");
        }
        else
        {
            countDownUI.SetActive(false);
        }
    }
}