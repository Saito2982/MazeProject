using UnityEngine;

public class CountDownController : MonoBehaviour
{
    public static Animator anim;
    [SerializeField]
    private GameObject countDownUI;
    private static bool isStart_anim;

    void Update()
    {
        isStart_anim = FlagController.getCounrDownAnimationFlag();
        anim = countDownUI.GetComponent<Animator>();
        if (isStart_anim)
        {
            countDownUI.SetActive(true);
            anim.SetTrigger("CountDownTrigger");
        }
        else
        {
            countDownUI.SetActive(false);
        }
    }
}