using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    void Update()
    {
        //時間経過によって太陽を動かす
        transform.rotation = transform.rotation * Quaternion.Euler(Time.deltaTime, 0, 0);
    }
}
