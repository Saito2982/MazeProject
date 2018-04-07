using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    private GameObject targetObj;
    private Vector3 targetPos;

    void Start()
    {
    	//追従対象のコンポーネント取得
        targetObj = GameObject.Find("unitychan");
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // コントローラ右スティックの移動量
        float mouseInputX = Input.GetAxis("Horizontal2");
        float mouseInputY = Input.GetAxis("Vertical2");
        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);  
    }
}