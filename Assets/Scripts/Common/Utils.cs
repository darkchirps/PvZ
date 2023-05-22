using UnityEngine;
using System.IO;
using UnityEditor;
using System.Collections;
using System;
using Object = System.Object;
/// <summary>
/// 多功能脚本
/// </summary>
public class Utils
{
    //将鼠标坐标转换成世界坐标
    public static Vector3 TranlateScreenToworld(Vector3 position)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y,0);
    }

    /// <summary>
    /// 用于读取和编写本地数据
    /// </summary>
    public static void SaveData(string key, object value) {
        if (value is int) {
            PlayerPrefs.SetInt(key, (int)value);
        } else if (value is float)  {
            PlayerPrefs.SetFloat(key, (float)value);
        } else if (value is string) {
            PlayerPrefs.SetString(key, (string)value);
        } else if (value is bool) {
            PlayerPrefs.SetInt(key, (bool)value ? 1 : 0);
        } else {
            Debug.LogError("Unsupported data type!");
            return;
        }
        PlayerPrefs.Save();
    }
    public static T LoadData<T>(string key, T defaultValue = default(T)) {
        if (typeof(T) == typeof(int)) {
            return (T)(object)PlayerPrefs.GetInt(key, (int)(object)defaultValue);
        } else if (typeof(T) == typeof(float)) {
            return (T)(object)PlayerPrefs.GetFloat(key, (float)(object)defaultValue);
        } else if (typeof(T) == typeof(string)) {
            return (T)(object)PlayerPrefs.GetString(key, (string)(object)defaultValue);
        } else if (typeof(T) == typeof(bool)) {
            int value = PlayerPrefs.GetInt(key, (bool)(object)defaultValue ? 1 : 0);
            return (T)(object)(value == 1);
        } else {
            Debug.LogError("Unsupported data type!");
            return defaultValue;
        }
    }

    /// <summary>
    /// 输入一个日期和天数，返回该活动的剩余时间
    /// </summary>
    public static string GetRemainingTime1(DateTime startDate, int durationDays) {
        DateTime endDate = startDate.AddDays(durationDays); // 计算活动结束时间
        TimeSpan remainingTime = endDate - DateTime.Now; // 计算剩余时间
        //Debug.Log("活动剩余时间：" + remainingTime.ToString(@"dd\.hh\:mm\:ss")); // 输出剩余时间
        return remainingTime.ToString(@"dd\.hh\:mm\:ss");
    }

    /// <summary>
    /// 输入一个周几和天数，返回该活动的剩余时间
    /// </summary>
    public static string GetRemainingTime2(int startWeekday, int durationDays) {
        DateTime now = DateTime.Now;
        int daysPassed = (now.DayOfWeek - (DayOfWeek)startWeekday + 7) % 7;
        TimeSpan remainingTime = TimeSpan.FromDays(durationDays) - TimeSpan.FromDays(daysPassed) - now.TimeOfDay;
        if (remainingTime < TimeSpan.Zero)
        {
            remainingTime = TimeSpan.Zero;
        }
        return remainingTime.ToString(@"dd\.hh\:mm\:ss"); ;
    }

    /*———————————————————资源加载相关———————————————————*/
    /// <summary>
    /// 输入指定预制体路径 返回资源
    /// </summary>
    public static GameObject LoadPrefab(string path) {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null) {
            // 加载失败，输出错误信息
            Debug.LogError("Failed to load prefab: " + path);
            return null;
        } else {
            return prefab;
        }
    }

    /// <summary>
    /// 输入指定图片路径 返回资源
    /// </summary>
    public static Sprite LoadSprite(string path) {
        Sprite image = Resources.Load<Sprite>(path);
        if (image == null) {
            // 加载失败，输出错误信息
            Debug.LogError("Failed to load image: " + path);
            return null;
        } else {
            return image;
        }
    }

    /// <summary>
    /// 输入json路径 返回其数据
    /// </summary>
    public static DataObj.JsonData JsondataOutput(string path) {
        string filePath = Application.dataPath + path;
        DataObj.JsonData data;
        if (File.Exists(filePath)) {
            //读取JSON文件内容
            string jsonContent = File.ReadAllText(filePath);
            //将JSON字符串转换为Data类的实例
            data = JsonUtility.FromJson<DataObj.JsonData>(jsonContent);
        } else {
            Debug.LogError("File not found: " + filePath);
            data =null;
        }
        return data;
    }

    public static DataObj.plantList GetPlantData()
    {
        string filePath = Application.dataPath + "/Resources/jsonData/plantData.json";
        DataObj.plantList data;
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<DataObj.plantList>(jsonContent);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            data = null;
        }
        return data;
    }
    public static DataObj.zombieList GetZombieData()
    {
        string filePath = Application.dataPath + "/Resources/jsonData/zombieData.json";
        DataObj.zombieList data;
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<DataObj.zombieList>(jsonContent);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            data = null;
        }
        return data;
    }
}
