using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {
	private static bool isStart_anim = false;
	private static bool isStart_timer = false;


	public static void setCountDownAnimationFlag() {
		if (isStart_anim)
        {
            isStart_anim = false;
        }
        else
        {
            isStart_anim = true;
        }
	}

	public static bool getCounrDownAnimationFlag() {
		return isStart_anim;
	}

	public static void setTimerFlag() {
		if (isStart_timer)
        {
            isStart_timer = false;
        }
        else
        {
            isStart_timer = true;
        }
	}

	public static bool getTimerFlag() {
		return isStart_timer;
	}
}
