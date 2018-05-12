using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {
    //カウントダウンアニメーションフラグ
	private static bool isStart_anim = false;
    //タイマーフラグ
	private static bool isStart_timer = false;


	public static void setCountDownAnimationFlag(bool flag)
    {
        isStart_anim = flag;
	}

	public static bool getCountDownAnimationFlag() {
		return isStart_anim;
	}

	public static void setTimerFlag(bool flag)
    {
        isStart_timer = flag;
	}

	public static bool getTimerFlag() {
		return isStart_timer;
	}
}
