using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {
	private static bool isStart_anim = false;
	private static bool isStart_timer = false;


	public static void setCountDownAnimationFlag(bool flag)
    {
        isStart_anim = flag;
	}

	public static bool getCounrDownAnimationFlag() {
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
