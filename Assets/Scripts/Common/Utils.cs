using UnityEngine;
using System.IO;
using UnityEditor;
using System.Collections;
using System;
using Object = System.Object;
/// <summary>
/// �๦�ܽű�
/// </summary>
public class Utils
{
    //���������ת������������
    public static Vector3 TranlateScreenToworld(Vector3 position)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y,0);
    }

    /// <summary>
    /// ���ڶ�ȡ�ͱ�д��������
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
    /// ����һ�����ں����������ظû��ʣ��ʱ��
    /// </summary>
    public static string GetRemainingTime1(DateTime startDate, int durationDays) {
        DateTime endDate = startDate.AddDays(durationDays); // ��������ʱ��
        TimeSpan remainingTime = endDate - DateTime.Now; // ����ʣ��ʱ��
        //Debug.Log("�ʣ��ʱ�䣺" + remainingTime.ToString(@"dd\.hh\:mm\:ss")); // ���ʣ��ʱ��
        return remainingTime.ToString(@"dd\.hh\:mm\:ss");
    }

    /// <summary>
    /// ����һ���ܼ������������ظû��ʣ��ʱ��
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

    /*����������������������������������������Դ������ء�������������������������������������*/
    /// <summary>
    /// ����ָ��Ԥ����·�� ������Դ
    /// </summary>
    public static GameObject LoadPrefab(string path) {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null) {
            // ����ʧ�ܣ����������Ϣ
            Debug.LogError("Failed to load prefab: " + path);
            return null;
        } else {
            return prefab;
        }
    }

    /// <summary>
    /// ����ָ��ͼƬ·�� ������Դ
    /// </summary>
    public static Sprite LoadSprite(string path) {
        Sprite image = Resources.Load<Sprite>(path);
        if (image == null) {
            // ����ʧ�ܣ����������Ϣ
            Debug.LogError("Failed to load image: " + path);
            return null;
        } else {
            return image;
        }
    }

    /// <summary>
    /// ����json·�� ����������
    /// </summary>
    public static DataObj.JsonData JsondataOutput(string path) {
        string filePath = Application.dataPath + path;
        DataObj.JsonData data;
        if (File.Exists(filePath)) {
            //��ȡJSON�ļ�����
            string jsonContent = File.ReadAllText(filePath);
            //��JSON�ַ���ת��ΪData���ʵ��
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
