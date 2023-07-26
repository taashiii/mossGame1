using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float riseSpeed = 0.1f; // 水面の上昇速度（高さの増加量）
    public float riseInterval = 5f; // 水面が上昇する間隔（秒）

    private float timer = 0f; // タイマー

    void Update()
    {
        // タイマーを増加させる
        timer += Time.deltaTime;

        // 指定した間隔で水面の高さを上げる
        if (timer >= riseInterval)
        {
            timer = 0f;
            RiseWaterLevel();
        }
    }

    void RiseWaterLevel()
    {
        // 現在の高さを取得
        Vector3 currentPosition = transform.position;

        // 水面の高さを上昇させる
        currentPosition.y += riseSpeed;

        // 上昇後の高さを設定
        transform.position = currentPosition;
    }
    
        
    }

    
