using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    private Rigidbody rb;
    //移動スピード
    private float speed = 2f;
    //Animatorを入れる変数
    private Animator animator;
    
    private float moveX = 0f;
    private float moveZ = 0f;
    //ランニングアニメーションキー
    private string key_run = "param_idletorunning";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Animatorにアクセスする
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
            if (moveX != 0 || moveZ != 0)
            {
                //入力があるときランニングアニメーション再生
                animator.SetBool(key_run, true);
            }
            
            //方向キーの入力がない時はランニングアニメーションをオフにする
            else
            {
                animator.SetBool(key_run, false);
            }    

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveX, 0, moveZ);
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * moveZ + Camera.main.transform.right * moveX;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

    }
}