using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 时间管理系统，为单例模式
/// 调用需要使用 TimeManager.instance.[publicOption]
/// </summary>
public class TimeManager : MonoBehaviour
{
    // 将 TimeManager 实现为单例，
    // 保证每个脚本访问的都是同一个时间管理器
    public static TimeManager instance;

    [Tooltip("控制时间流速")]
    public float timeScale = 1.0f;

    [Tooltip("游戏运行时间")]
    private float gameTime = 0;


    private int minutes;
    private int seconds;

    private void Awake()
    {
        // 通过检查单例实例是否为空来保证只有一个时间管理器
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            gameTime += Time.deltaTime * timeScale;
            minutes = (int)gameTime / 60;
            seconds = (int)gameTime % 60;
        }
    }

    /// <summary>
    /// 获取游戏时间
    /// </summary>
    /// <returns></returns>
    public string GetTime()
    {

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// 暂停游戏时间
    /// </summary>
    public void PauseTime()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// 继续游戏时间
    /// </summary>
    public void ResumeTime()
    {
        Time.timeScale = timeScale;
    }

    /// <summary>
    /// 减速时间
    /// </summary>
    /// <param name="factor">减速倍数</param>
    public void SlowTime(float factor)
    {

        timeScale /= factor;
    }

    /// <summary>
    /// 加速时间
    /// </summary>
    /// <param name="factor">加速倍数</param>
    public void SpeedTime(float factor)
    {
        timeScale *= factor;
    }
}
