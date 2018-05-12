using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject wallPrefab;
    [SerializeField]
    private GameObject goalPrefab;
    [SerializeField]
    private GameObject startPrefab;
    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private int mazesize;

    private GameObject MainCam;
    private GameObject SubCam;

    private int mazeHeight;
    private int mazeWidth;
    private bool[,] maze;
    private GameObject[,] mazeObject;
    private List<Vector2> searchDirections = new List<Vector2> { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

    private void Start()
    {
        //タイマーフラグOFF
        FlagController.setTimerFlag(false);
        //カウントダウンフラグOFF
        FlagController.setCountDownAnimationFlag(false);

        //迷路作成
        CreateMaze(mazesize, mazesize);
        MainCam = GameObject.Find("MainCamera");
        SubCam = GameObject.Find("SubCamera");

        //上からのカメラを有効可
        SubCam.SetActive(true);
    }

    private void CreateMaze(int height, int width)
    {
        mazeWidth = width;
        mazeHeight = height;

        InitializeMaze();
        StartCoroutine(DigMaze());

        //Start,Goalの作成
        CreateSG();
    }

    private void InitializeMaze()
    {
        maze = new bool[mazeWidth, mazeHeight];
        mazeObject = new GameObject[mazeWidth, mazeHeight];
        for (int i = 0; i < mazeWidth; i++)
        {
            for (int j = 0; j < mazeHeight; j++)
            {
                maze[i, j] = true;
                mazeObject[i, j] = Instantiate(wallPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
            }
        }

        var centered = new Vector3(mazeWidth / 2f - 0.5f, 0, mazeHeight / 2f - 0.5f);

        Camera.transform.position = centered + Vector3.up * ((mazeWidth + mazeHeight) / 2f);
    }

    private IEnumerator DigMaze()
    {
        int startPosW = Enumerable.Range(0, mazeWidth).Where(i => i % 2 != 0).OrderBy(i => Guid.NewGuid()).First();
        int startPosH = Enumerable.Range(0, mazeHeight).Where(i => i % 2 != 0).OrderBy(i => Guid.NewGuid()).First();
        yield return Dig(new Vector2(startPosW, startPosH));

        //カウントダウンアニメーションフラグON
        FlagController.setCountDownAnimationFlag(true);
        //カウントダウンアニメーション終了まで待機
        Invoke("DelayMethod", 5.0f);

    }

    private IEnumerator Dig(Vector2 point)
    {
        yield return RemoveWall(point);

        foreach (var dir in searchDirections.OrderBy(i => Guid.NewGuid()))
        {
            var checkPos = point + dir * 2;
            if (IsInBoard(checkPos) && maze[(int)checkPos.x, (int)checkPos.y])
            {
                yield return RemoveWall(point + dir);
                yield return Dig(checkPos);
            }
        }
    }

    private IEnumerator RemoveWall(Vector2 point)
    {
        var w = (int)point.x;
        var h = (int)point.y;
        maze[w, h] = false;
        Destroy(mazeObject[w, h]);
        yield return new WaitForSeconds(0.01f);
    }

    private bool IsInBoard(Vector2 pos)
    {
        return pos.x >= 0 && pos.y >= 0 && pos.x < mazeWidth && pos.y < mazeHeight;
    }

    private void CreateSG()
    {
        Destroy(mazeObject[1, 0]);								//Start
        Destroy(mazeObject[mazeHeight - 2, mazeWidth - 1]);		//Goal

        mazeObject[1, 0] = Instantiate(startPrefab, new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
        mazeObject[mazeHeight - 2, mazeWidth - 1] = Instantiate(goalPrefab, new Vector3(mazeHeight - 2, 0, mazeWidth - 1), Quaternion.identity) as GameObject;
        
    }

    void DelayMethod()
    {
    	//アニメーション終了時にスタートラインブロック破壊
        Destroy(mazeObject[1, 0]);
        //カウントダウンアニメーションフラグOFF
        FlagController.setCountDownAnimationFlag(false);
        //タイマースタート
        FlagController.setTimerFlag(true);
        //キャラ追従カメラに切り替え
        SubCam.SetActive(false);
    }
}